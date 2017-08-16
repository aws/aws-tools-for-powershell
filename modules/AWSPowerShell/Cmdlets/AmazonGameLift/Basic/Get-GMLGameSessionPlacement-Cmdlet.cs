/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Retrieves properties and current status of a game session placement request. To get
    /// game session placement details, specify the placement ID. If successful, a <a>GameSessionPlacement</a>
    /// object is returned.
    /// 
    ///  
    /// <para>
    /// Game-session-related operations include:
    /// </para><ul><li><para><a>CreateGameSession</a></para></li><li><para><a>DescribeGameSessions</a></para></li><li><para><a>DescribeGameSessionDetails</a></para></li><li><para><a>SearchGameSessions</a></para></li><li><para><a>UpdateGameSession</a></para></li><li><para><a>GetGameSessionLogUrl</a></para></li><li><para>
    /// Game session placements
    /// </para><ul><li><para><a>StartGameSessionPlacement</a></para></li><li><para><a>DescribeGameSessionPlacement</a></para></li><li><para><a>StopGameSessionPlacement</a></para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLGameSessionPlacement")]
    [OutputType("Amazon.GameLift.Model.GameSessionPlacement")]
    [AWSCmdlet("Invokes the DescribeGameSessionPlacement operation against Amazon GameLift Service.", Operation = new[] {"DescribeGameSessionPlacement"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSessionPlacement",
        "This cmdlet returns a GameSessionPlacement object.",
        "The service call response (type Amazon.GameLift.Model.DescribeGameSessionPlacementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLGameSessionPlacementCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter PlacementId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a game session placement to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String PlacementId { get; set; }
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
            
            context.PlacementId = this.PlacementId;
            
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
            var request = new Amazon.GameLift.Model.DescribeGameSessionPlacementRequest();
            
            if (cmdletContext.PlacementId != null)
            {
                request.PlacementId = cmdletContext.PlacementId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GameSessionPlacement;
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
        
        private Amazon.GameLift.Model.DescribeGameSessionPlacementResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeGameSessionPlacementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeGameSessionPlacement");
            try
            {
                #if DESKTOP
                return client.DescribeGameSessionPlacement(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeGameSessionPlacementAsync(request);
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
            public System.String PlacementId { get; set; }
        }
        
    }
}
