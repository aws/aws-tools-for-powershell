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
    /// Retrieves information on VPC peering connections. Use this operation to get peering
    /// information for all fleets or for one specific fleet ID. 
    /// 
    ///  
    /// <para>
    /// To retrieve connection information, call this operation from the AWS account that
    /// is used to manage the Amazon GameLift fleets. Specify a fleet ID or leave the parameter
    /// empty to retrieve all connection records. If successful, the retrieved information
    /// includes both active and pending connections. Active connections identify the IpV4
    /// CIDR block that the VPC uses to connect. 
    /// </para><ul><li><para><a>CreateVpcPeeringAuthorization</a></para></li><li><para><a>DescribeVpcPeeringAuthorizations</a></para></li><li><para><a>DeleteVpcPeeringAuthorization</a></para></li><li><para><a>CreateVpcPeeringConnection</a></para></li><li><para><a>DescribeVpcPeeringConnections</a></para></li><li><para><a>DeleteVpcPeeringConnection</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLVpcPeeringConnection")]
    [OutputType("Amazon.GameLift.Model.VpcPeeringConnection")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeVpcPeeringConnections API operation.", Operation = new[] {"DescribeVpcPeeringConnections"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.VpcPeeringConnection",
        "This cmdlet returns a collection of VpcPeeringConnection objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeVpcPeeringConnectionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLVpcPeeringConnectionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
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
            
            context.FleetId = this.FleetId;
            
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
            var request = new Amazon.GameLift.Model.DescribeVpcPeeringConnectionsRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpcPeeringConnections;
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
        
        private Amazon.GameLift.Model.DescribeVpcPeeringConnectionsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeVpcPeeringConnectionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeVpcPeeringConnections");
            try
            {
                #if DESKTOP
                return client.DescribeVpcPeeringConnections(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVpcPeeringConnectionsAsync(request);
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
            public System.String FleetId { get; set; }
        }
        
    }
}
