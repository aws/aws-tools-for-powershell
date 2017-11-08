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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Updates the type of medium changer in a tape gateway. When you activate a tape gateway,
    /// you select a medium changer type for the tape gateway. This operation enables you
    /// to select a different type of medium changer after a tape gateway is activated. This
    /// operation is only supported in the tape gateway architecture.
    /// </summary>
    [Cmdlet("Update", "SGVTLDeviceType", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Storage Gateway UpdateVTLDeviceType API operation.", Operation = new[] {"UpdateVTLDeviceType"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.StorageGateway.Model.UpdateVTLDeviceTypeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSGVTLDeviceTypeCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter DeviceType
        /// <summary>
        /// <para>
        /// <para>The type of medium changer you want to select.</para><para> Valid Values: "STK-L700", "AWS-Gateway-VTL"</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceType { get; set; }
        #endregion
        
        #region Parameter VTLDeviceARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the medium changer you want to select.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VTLDeviceARN { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VTLDeviceARN", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SGVTLDeviceType (UpdateVTLDeviceType)"))
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
            
            context.DeviceType = this.DeviceType;
            context.VTLDeviceARN = this.VTLDeviceARN;
            
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
            var request = new Amazon.StorageGateway.Model.UpdateVTLDeviceTypeRequest();
            
            if (cmdletContext.DeviceType != null)
            {
                request.DeviceType = cmdletContext.DeviceType;
            }
            if (cmdletContext.VTLDeviceARN != null)
            {
                request.VTLDeviceARN = cmdletContext.VTLDeviceARN;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.StorageGateway.Model.UpdateVTLDeviceTypeResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.UpdateVTLDeviceTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "UpdateVTLDeviceType");
            try
            {
                #if DESKTOP
                return client.UpdateVTLDeviceType(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateVTLDeviceTypeAsync(request);
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
            public System.String DeviceType { get; set; }
            public System.String VTLDeviceARN { get; set; }
        }
        
    }
}
