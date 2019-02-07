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
    /// Retrieves valid VPC peering authorizations that are pending for the AWS account. This
    /// operation returns all VPC peering authorizations and requests for peering. This includes
    /// those initiated and received by this account. 
    /// 
    ///  <ul><li><para><a>CreateVpcPeeringAuthorization</a></para></li><li><para><a>DescribeVpcPeeringAuthorizations</a></para></li><li><para><a>DeleteVpcPeeringAuthorization</a></para></li><li><para><a>CreateVpcPeeringConnection</a></para></li><li><para><a>DescribeVpcPeeringConnections</a></para></li><li><para><a>DeleteVpcPeeringConnection</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLVpcPeeringAuthorization")]
    [OutputType("Amazon.GameLift.Model.VpcPeeringAuthorization")]
    [AWSCmdlet("Calls the Amazon GameLift Service DescribeVpcPeeringAuthorizations API operation.", Operation = new[] {"DescribeVpcPeeringAuthorizations"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.VpcPeeringAuthorization",
        "This cmdlet returns a collection of VpcPeeringAuthorization objects.",
        "The service call response (type Amazon.GameLift.Model.DescribeVpcPeeringAuthorizationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetGMLVpcPeeringAuthorizationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
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
            var request = new Amazon.GameLift.Model.DescribeVpcPeeringAuthorizationsRequest();
            
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpcPeeringAuthorizations;
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
        
        private Amazon.GameLift.Model.DescribeVpcPeeringAuthorizationsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DescribeVpcPeeringAuthorizationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DescribeVpcPeeringAuthorizations");
            try
            {
                #if DESKTOP
                return client.DescribeVpcPeeringAuthorizations(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeVpcPeeringAuthorizationsAsync(request);
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
        }
        
    }
}
