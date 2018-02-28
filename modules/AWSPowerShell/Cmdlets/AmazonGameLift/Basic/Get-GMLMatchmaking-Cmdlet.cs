/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// including status and--once a successful match is made--acquire connection information
    /// for the resulting new game session. 
    /// 
    ///  
    /// <para>
    /// You can use this operation to track the progress of matchmaking requests (through
    /// polling) as an alternative to using event notifications. See more details on tracking
    /// matchmaking requests through polling or notifications in <a>StartMatchmaking</a>.
    /// 
    /// </para><para>
    /// To request matchmaking tickets, provide a list of up to 10 ticket IDs. If the request
    /// is successful, a ticket object is returned for each requested ID that currently exists.
    /// </para><para>
    /// Matchmaking-related operations include:
    /// </para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li><li><para><a>StartMatchBackfill</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLMatchmaking")]
    [OutputType("Amazon.GameLift.Model.MatchmakingTicket")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeMatchmaking API operation.", Operation = new[] {"DescribeMatchmaking"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingTicket",
        "This cmdlet returns a collection of MatchmakingTicket objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeMatchmakingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLMatchmakingCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking ticket. You can include up to 10 ID values. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("TicketIds")]
        public System.String[] TicketId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.TicketId != null)
            {
                context.TicketIds = new List<System.String>(this.TicketId);
            }
            
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
            
            if (cmdletContext.TicketIds != null)
            {
                request.TicketIds = cmdletContext.TicketIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TicketList;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeMatchmakingAsync(request);
                return task.Result;
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
            public List<System.String> TicketIds { get; set; }
        }
        
    }
}
