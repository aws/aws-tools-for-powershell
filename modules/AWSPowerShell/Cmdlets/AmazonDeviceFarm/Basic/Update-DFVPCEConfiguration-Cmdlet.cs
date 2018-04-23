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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Updates information about an existing Amazon Virtual Private Cloud (VPC) endpoint
    /// configuration.
    /// </summary>
    [Cmdlet("Update", "DFVPCEConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.VPCEConfiguration")]
    [AWSCmdlet("Calls the AWS Device Farm UpdateVPCEConfiguration API operation.", Operation = new[] {"UpdateVPCEConfiguration"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.VPCEConfiguration",
        "This cmdlet returns a VPCEConfiguration object.",
        "The service call response (type Amazon.DeviceFarm.Model.UpdateVPCEConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDFVPCEConfigurationCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the VPC endpoint configuration you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ServiceDnsName
        /// <summary>
        /// <para>
        /// <para>The DNS (domain) name used to connect to your private service in your Amazon VPC.
        /// The DNS name must not already be in use on the Internet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceDnsName { get; set; }
        #endregion
        
        #region Parameter VpceConfigurationDescription
        /// <summary>
        /// <para>
        /// <para>An optional description, providing more details about your VPC endpoint configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpceConfigurationDescription { get; set; }
        #endregion
        
        #region Parameter VpceConfigurationName
        /// <summary>
        /// <para>
        /// <para>The friendly name you give to your VPC endpoint configuration, to manage your configurations
        /// more easily.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpceConfigurationName { get; set; }
        #endregion
        
        #region Parameter VpceServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the VPC endpoint service running inside your AWS account that you want
        /// Device Farm to test.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpceServiceName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Arn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DFVPCEConfiguration (UpdateVPCEConfiguration)"))
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
            
            context.Arn = this.Arn;
            context.ServiceDnsName = this.ServiceDnsName;
            context.VpceConfigurationDescription = this.VpceConfigurationDescription;
            context.VpceConfigurationName = this.VpceConfigurationName;
            context.VpceServiceName = this.VpceServiceName;
            
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
            var request = new Amazon.DeviceFarm.Model.UpdateVPCEConfigurationRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ServiceDnsName != null)
            {
                request.ServiceDnsName = cmdletContext.ServiceDnsName;
            }
            if (cmdletContext.VpceConfigurationDescription != null)
            {
                request.VpceConfigurationDescription = cmdletContext.VpceConfigurationDescription;
            }
            if (cmdletContext.VpceConfigurationName != null)
            {
                request.VpceConfigurationName = cmdletContext.VpceConfigurationName;
            }
            if (cmdletContext.VpceServiceName != null)
            {
                request.VpceServiceName = cmdletContext.VpceServiceName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VpceConfiguration;
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
        
        private Amazon.DeviceFarm.Model.UpdateVPCEConfigurationResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.UpdateVPCEConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "UpdateVPCEConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateVPCEConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateVPCEConfigurationAsync(request);
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
            public System.String Arn { get; set; }
            public System.String ServiceDnsName { get; set; }
            public System.String VpceConfigurationDescription { get; set; }
            public System.String VpceConfigurationName { get; set; }
            public System.String VpceServiceName { get; set; }
        }
        
    }
}
