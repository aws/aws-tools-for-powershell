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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Retrieves one or more matchmaking tickets. Use this operation to retrieve ticket information,
    /// including--after a successful match is made--connection information for the resulting
    /// new game session. 
    /// 
    ///  
    /// <para>
    /// To request matchmaking tickets, provide a list of up to 10 ticket IDs. If the request
    /// is successful, a ticket object is returned for each requested ID that currently exists.
    /// </para><para>
    /// This operation is not designed to be continually called to track matchmaking ticket
    /// status. This practice can cause you to exceed your API limit, which results in errors.
    /// Instead, as a best practice, set up an Amazon Simple Notification Service to receive
    /// notifications, and provide the topic ARN in the matchmaking configuration.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-client.html">
    /// Add FlexMatch to a game client</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-notification.html">
    /// Set Up FlexMatch event notification</a></para>
    /// </summary>
    [Cmdlet("Get", "GMLMatchmaking")]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeMatchmaking API operation.", Operation = new[] {"DescribeMatchmaking"}, SelectReturnType = typeof(Amazon.GameLift.Model.DescribeMatchmakingResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket or Amazon.GameLift.Model.DescribeMatchmakingResponse",
        "This cmdlet returns a collection of Amazon.GameLift.Model.MatchmakingTicket objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeMatchmakingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGMLMatchmakingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a matchmaking ticket. You can include up to 10 ID values.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TicketIds")]
        public System.String[] TicketId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TicketList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.DescribeMatchmakingResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.DescribeMatchmakingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TicketList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TicketId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TicketId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TicketId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.DescribeMatchmakingResponse, GetGMLMatchmakingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TicketId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.TicketId != null)
            {
                context.TicketId = new List<System.String>(this.TicketId);
            }
            #if MODULAR
            if (this.TicketId == null && ParameterWasBound(nameof(this.TicketId)))
            {
                WriteWarning("You are passing $null as a value for parameter TicketId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.GameLift.Model.DescribeMatchmakingRequest();
            
            if (cmdletContext.TicketId != null)
            {
                request.TicketIds = cmdletContext.TicketId;
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
        
        private Amazon.GameLift.Model.DescribeMatchmakingResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeMatchmakingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeMatchmaking");
            try
            {
                #if DESKTOP
                return client.DescribeMatchmaking(request);
                #elif CORECLR
                return client.DescribeMatchmakingAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> TicketId { get; set; }
            public System.Func<Amazon.GameLift.Model.DescribeMatchmakingResponse, GetGMLMatchmakingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TicketList;
        }
        
    }
}
