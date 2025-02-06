/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Ivschat;
using Amazon.Ivschat.Model;

namespace Amazon.PowerShell.Cmdlets.IVSC
{
    /// <summary>
    /// Gets summary information about all your rooms in the AWS region where the API request
    /// is processed. Results are sorted in descending order of <c>updateTime</c>.
    /// </summary>
    [Cmdlet("Get", "IVSCRoomList")]
    [OutputType("Amazon.Ivschat.Model.RoomSummary")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service Chat ListRooms API operation.", Operation = new[] {"ListRooms"}, SelectReturnType = typeof(Amazon.Ivschat.Model.ListRoomsResponse))]
    [AWSCmdletOutput("Amazon.Ivschat.Model.RoomSummary or Amazon.Ivschat.Model.ListRoomsResponse",
        "This cmdlet returns a collection of Amazon.Ivschat.Model.RoomSummary objects.",
        "The service call response (type Amazon.Ivschat.Model.ListRoomsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIVSCRoomListCmdlet : AmazonIvschatClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LoggingConfigurationIdentifier
        /// <summary>
        /// <para>
        /// <para>Logging-configuration identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfigurationIdentifier { get; set; }
        #endregion
        
        #region Parameter MessageReviewHandlerUri
        /// <summary>
        /// <para>
        /// <para>Filters the list to match the specified message review handler URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageReviewHandlerUri { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Filters the list to match the specified room name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of rooms to return. Default: 50.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The first room to retrieve. This is used for pagination; see the <c>nextToken</c>
        /// response field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Rooms'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Ivschat.Model.ListRoomsResponse).
        /// Specifying the name of a property of type Amazon.Ivschat.Model.ListRoomsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Rooms";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Ivschat.Model.ListRoomsResponse, GetIVSCRoomListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoggingConfigurationIdentifier = this.LoggingConfigurationIdentifier;
            context.MaxResult = this.MaxResult;
            context.MessageReviewHandlerUri = this.MessageReviewHandlerUri;
            context.Name = this.Name;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Ivschat.Model.ListRoomsRequest();
            
            if (cmdletContext.LoggingConfigurationIdentifier != null)
            {
                request.LoggingConfigurationIdentifier = cmdletContext.LoggingConfigurationIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MessageReviewHandlerUri != null)
            {
                request.MessageReviewHandlerUri = cmdletContext.MessageReviewHandlerUri;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Ivschat.Model.ListRoomsResponse CallAWSServiceOperation(IAmazonIvschat client, Amazon.Ivschat.Model.ListRoomsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service Chat", "ListRooms");
            try
            {
                #if DESKTOP
                return client.ListRooms(request);
                #elif CORECLR
                return client.ListRoomsAsync(request).GetAwaiter().GetResult();
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
            public System.String LoggingConfigurationIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String MessageReviewHandlerUri { get; set; }
            public System.String Name { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Ivschat.Model.ListRoomsResponse, GetIVSCRoomListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Rooms;
        }
        
    }
}
