using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vii
{
  public   class SendNotification
    {
        static int messageCount = 0;
       public  async Task SendTemplateNotificationsAsync(String message)
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(DispatcherConstants.FullAccessConnectionString, DispatcherConstants.NotificationHubName);
            Dictionary<string, string> templateParameters = new Dictionary<string, string>();
            
            messageCount++;

            // Send a template notification to each tag. This will go to any devices that
            // have subscribed to this tag with a template that includes "messageParam"
            // as a parameter
            foreach (var tag in DispatcherConstants.SubscriptionTags)
            {
                templateParameters["messageParam"] = $"Notification #{messageCount} to {tag}  {message} ";
                try
                {
                    await hub.SendTemplateNotificationAsync(templateParameters, tag);
                    Console.WriteLine($"Sent {message} to {tag} subscribers.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send template notification: {ex.Message}");
                }
            }

            Console.WriteLine($"Sent messages to {DispatcherConstants.SubscriptionTags.Length} tags.");
            
        }
    }
}
