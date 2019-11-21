/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Triggers an asynchronous flow to send text, SSML, or audio announcements to rooms
    /// that are identified by a search or filter.
    /// </summary>
    [Cmdlet("Send", "ALXBAnnouncement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Alexa For Business SendAnnouncement API operation.", Operation = new[] {"SendAnnouncement"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.SendAnnouncementResponse))]
    [AWSCmdletOutput("System.String or Amazon.AlexaForBusiness.Model.SendAnnouncementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.SendAnnouncementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendALXBAnnouncementCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        #region Parameter Content_AudioList
        /// <summary>
        /// <para>
        /// <para>The list of audio messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AlexaForBusiness.Model.Audio[] Content_AudioList { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique, user-specified identifier for the request that ensures idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter RoomFilter
        /// <summary>
        /// <para>
        /// <para>The filters to use to send an announcement to a specified list of rooms. The supported
        /// filter keys are RoomName, ProfileName, RoomArn, and ProfileArn. To send to all rooms,
        /// specify an empty RoomFilters list.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RoomFilters")]
        public Amazon.AlexaForBusiness.Model.Filter[] RoomFilter { get; set; }
        #endregion
        
        #region Parameter Content_SsmlList
        /// <summary>
        /// <para>
        /// <para>The list of SSML messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AlexaForBusiness.Model.Ssml[] Content_SsmlList { get; set; }
        #endregion
        
        #region Parameter Content_TextList
        /// <summary>
        /// <para>
        /// <para>The list of text messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AlexaForBusiness.Model.Text[] Content_TextList { get; set; }
        #endregion
        
        #region Parameter TimeToLiveInSecond
        /// <summary>
        /// <para>
        /// <para>The time to live for an announcement. Default is 300. If delivery doesn't occur within
        /// this time, the announcement is not delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeToLiveInSeconds")]
        public System.Int32? TimeToLiveInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnnouncementArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.SendAnnouncementResponse).
        /// Specifying the name of a property of type Amazon.AlexaForBusiness.Model.SendAnnouncementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnnouncementArn";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-ALXBAnnouncement (SendAnnouncement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.SendAnnouncementResponse, SendALXBAnnouncementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Content_AudioList != null)
            {
                context.Content_AudioList = new List<Amazon.AlexaForBusiness.Model.Audio>(this.Content_AudioList);
            }
            if (this.Content_SsmlList != null)
            {
                context.Content_SsmlList = new List<Amazon.AlexaForBusiness.Model.Ssml>(this.Content_SsmlList);
            }
            if (this.Content_TextList != null)
            {
                context.Content_TextList = new List<Amazon.AlexaForBusiness.Model.Text>(this.Content_TextList);
            }
            if (this.RoomFilter != null)
            {
                context.RoomFilter = new List<Amazon.AlexaForBusiness.Model.Filter>(this.RoomFilter);
            }
            #if MODULAR
            if (this.RoomFilter == null && ParameterWasBound(nameof(this.RoomFilter)))
            {
                WriteWarning("You are passing $null as a value for parameter RoomFilter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeToLiveInSecond = this.TimeToLiveInSecond;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AlexaForBusiness.Model.SendAnnouncementRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.AlexaForBusiness.Model.Content();
            List<Amazon.AlexaForBusiness.Model.Audio> requestContent_content_AudioList = null;
            if (cmdletContext.Content_AudioList != null)
            {
                requestContent_content_AudioList = cmdletContext.Content_AudioList;
            }
            if (requestContent_content_AudioList != null)
            {
                request.Content.AudioList = requestContent_content_AudioList;
                requestContentIsNull = false;
            }
            List<Amazon.AlexaForBusiness.Model.Ssml> requestContent_content_SsmlList = null;
            if (cmdletContext.Content_SsmlList != null)
            {
                requestContent_content_SsmlList = cmdletContext.Content_SsmlList;
            }
            if (requestContent_content_SsmlList != null)
            {
                request.Content.SsmlList = requestContent_content_SsmlList;
                requestContentIsNull = false;
            }
            List<Amazon.AlexaForBusiness.Model.Text> requestContent_content_TextList = null;
            if (cmdletContext.Content_TextList != null)
            {
                requestContent_content_TextList = cmdletContext.Content_TextList;
            }
            if (requestContent_content_TextList != null)
            {
                request.Content.TextList = requestContent_content_TextList;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            if (cmdletContext.RoomFilter != null)
            {
                request.RoomFilters = cmdletContext.RoomFilter;
            }
            if (cmdletContext.TimeToLiveInSecond != null)
            {
                request.TimeToLiveInSeconds = cmdletContext.TimeToLiveInSecond.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.AlexaForBusiness.Model.SendAnnouncementResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.SendAnnouncementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "SendAnnouncement");
            try
            {
                #if DESKTOP
                return client.SendAnnouncement(request);
                #elif CORECLR
                return client.SendAnnouncementAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Audio> Content_AudioList { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Ssml> Content_SsmlList { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Text> Content_TextList { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Filter> RoomFilter { get; set; }
            public System.Int32? TimeToLiveInSecond { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.SendAnnouncementResponse, SendALXBAnnouncementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnnouncementArn;
        }
        
    }
}
