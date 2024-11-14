using Meeting.Models.Integrations.Zoom;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pathoschild.Http.Client.Internal;
using ZoomNet;
using ZoomNet.Models;
using ZoomNet.Utilities;

namespace Meeting.Helpers;

public enum MeetingType
{
    Zoom,
    GoogleMeet,
    MicrosoftTeams
}

public class MeetingManager
{
    private readonly ZoomIntegrationModel _zoomIntegration;

    public MeetingManager(ZoomIntegrationModel zoomIntegration)
    {
        _zoomIntegration = zoomIntegration;
    }

    public async Task<ResponseModel?> Create(MeetingType meetingType, string title, string agendaTitle, DateTime startDateTime, int duration)
    {
        switch (meetingType)
        {
            case MeetingType.Zoom:
                if (_zoomIntegration != null)
                {
                    var client = new ZoomClient(OAuthConnectionInfo.ForServerToServer(_zoomIntegration.ClientId, _zoomIntegration.ClientSecret, _zoomIntegration.AccountId),
                        new ZoomClientOptions
                        {
                            LogLevelFailedCalls = LogLevel.Warning,
                            LogLevelSuccessfulCalls = LogLevel.Information
                        });

                    var users = await client.Users.GetAllAsync(UserStatus.Active, null, 30, null, CancellationToken.None);

                    if (users != null && users.Records.Any())
                    {
                        foreach (var user in users.Records)
                        {
                            var meetingResult = await client.Meetings.CreateScheduledMeetingAsync(userId: user.Email,
                                                                                                  topic: title,
                                                                                                  agenda: agendaTitle,
                                                                                                  start: startDateTime,
                                                                                                  duration: 30,
                                                                                                  timeZone: TimeZones.Europe_Istanbul);

                            return new ResponseModel
                            {
                                JoinID=Convert.ToString(meetingResult.Id),
                                DirectUrl = meetingResult.StartUrl,
                                JoinUrl = meetingResult.JoinUrl,
                                Password = meetingResult.Password
                            };
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                break;
            case MeetingType.GoogleMeet:
                // TODO: İlerde Google Meet kullanılarak bir entegrasyon yapılacak ise buradaki işlemler yapılır.
                return null;
            case MeetingType.MicrosoftTeams:
                // TODO: İlerde Microsoft Teams kullanılarak bir entegrasyon yapılacak ise buradaki işlemler yapılır.
                return null;
            default:
                throw new ArgumentOutOfRangeException(nameof(meetingType), meetingType, null);

        }

        return null;
    }
}