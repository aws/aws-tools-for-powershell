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
    /// Removes a VPC peering connection. To delete the connection, you must have a valid
    /// authorization for the VPC peering connection that you want to delete. You can check
    /// for an authorization by calling <a>DescribeVpcPeeringAuthorizations</a> or request
    /// a new one using <a>CreateVpcPeeringAuthorization</a>. 
    /// 
    ///  
    /// <para>
    /// Once a valid authorization exists, call this operation from the AWS account that is
    /// used to manage the Amazon GameLift fleets. Identify the connection to delete by the
    /// connection ID and fleet ID. If successful, the connection is removed. 
    /// </para><ul><li><para><a>CreateVpcPeeringAuthorization</a></para></li><li><para><a>DescribeVpcPeeringAuthorizations</a></para></li><li><para><a>DeleteVpcPeeringAuthorization</a></para></li><li><para><a>CreateVpcPeeringConnection</a></para></li><li><para><a>DescribeVpcPeeringConnections</a></para></li><li><para><a>DeleteVpcPeeringConnection</a></para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "GMLVpcPeeringConnection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service DeleteVpcPeeringConnection API operation.", Operation = new[] {"DeleteVpcPeeringConnection"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the FleetId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.GameLift.Model.DeleteVpcPeeringConnectionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveGMLVpcPeeringConnectionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet. This value must match the fleet ID referenced in the
        /// VPC peering connection record.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter VpcPeeringConnectionId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a VPC peering connection. This value is included in the <a>VpcPeeringConnection</a>
        /// object, which can be retrieved by calling <a>DescribeVpcPeeringConnections</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpcPeeringConnectionId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the FleetId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-GMLVpcPeeringConnection (DeleteVpcPeeringConnection)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FleetId = this.FleetId;
            context.VpcPeeringConnectionId = this.VpcPeeringConnectionId;
            
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
            var request = new Amazon.GameLift.Model.DeleteVpcPeeringConnectionRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.VpcPeeringConnectionId != null)
            {
                request.VpcPeeringConnectionId = cmdletContext.VpcPeeringConnectionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.FleetId;
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
        
        private Amazon.GameLift.Model.DeleteVpcPeeringConnectionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.DeleteVpcPeeringConnectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "DeleteVpcPeeringConnection");
            try
            {
                #if DESKTOP
                return client.DeleteVpcPeeringConnection(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteVpcPeeringConnectionAsync(request);
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
            public System.String VpcPeeringConnectionId { get; set; }
        }
        
    }
}
