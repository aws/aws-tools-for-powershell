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
using Amazon.CloudHSMV2;
using Amazon.CloudHSMV2.Model;

namespace Amazon.PowerShell.Cmdlets.HSM2
{
    /// <summary>
    /// Creates a new hardware security module (HSM) in the specified AWS CloudHSM cluster.
    /// </summary>
    [Cmdlet("New", "HSM2Hsm", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudHSMV2.Model.Hsm")]
    [AWSCmdlet("Calls the AWS Cloud HSM V2 CreateHsm API operation.", Operation = new[] {"CreateHsm"})]
    [AWSCmdletOutput("Amazon.CloudHSMV2.Model.Hsm",
        "This cmdlet returns a Hsm object.",
        "The service call response (type Amazon.CloudHSMV2.Model.CreateHsmResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewHSM2HsmCmdlet : AmazonCloudHSMV2ClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where you are creating the HSM. To find the cluster's Availability
        /// Zones, use <a>DescribeClusters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>The identifier (ID) of the HSM's cluster. To find the cluster ID, use <a>DescribeClusters</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClusterId { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>The HSM's IP address. If you specify an IP address, use an available address from
        /// the subnet that maps to the Availability Zone where you are creating the HSM. If you
        /// don't specify an IP address, one is chosen for you from that subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IpAddress { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-HSM2Hsm (CreateHsm)"))
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
            
            context.AvailabilityZone = this.AvailabilityZone;
            context.ClusterId = this.ClusterId;
            context.IpAddress = this.IpAddress;
            
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
            var request = new Amazon.CloudHSMV2.Model.CreateHsmRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddress = cmdletContext.IpAddress;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Hsm;
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
        
        private Amazon.CloudHSMV2.Model.CreateHsmResponse CallAWSServiceOperation(IAmazonCloudHSMV2 client, Amazon.CloudHSMV2.Model.CreateHsmRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud HSM V2", "CreateHsm");
            try
            {
                #if DESKTOP
                return client.CreateHsm(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateHsmAsync(request);
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
            public System.String AvailabilityZone { get; set; }
            public System.String ClusterId { get; set; }
            public System.String IpAddress { get; set; }
        }
        
    }
}
