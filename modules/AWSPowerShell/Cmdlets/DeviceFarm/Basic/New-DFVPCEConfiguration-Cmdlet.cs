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
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Creates a configuration record in Device Farm for your Amazon Virtual Private Cloud
    /// (VPC) endpoint.
    /// </summary>
    [Cmdlet("New", "DFVPCEConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.VPCEConfiguration")]
    [AWSCmdlet("Calls the AWS Device Farm CreateVPCEConfiguration API operation.", Operation = new[] {"CreateVPCEConfiguration"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.VPCEConfiguration or Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.VPCEConfiguration object.",
        "The service call response (type Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDFVPCEConfigurationCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter ServiceDnsName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the service running in your VPC that you want Device Farm to test.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ServiceDnsName { get; set; }
        #endregion
        
        #region Parameter VpceConfigurationDescription
        /// <summary>
        /// <para>
        /// <para>An optional description that provides details about your VPC endpoint configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpceConfigurationDescription { get; set; }
        #endregion
        
        #region Parameter VpceConfigurationName
        /// <summary>
        /// <para>
        /// <para>The friendly name you give to your VPC endpoint configuration, to manage your configurations
        /// more easily.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VpceConfigurationName { get; set; }
        #endregion
        
        #region Parameter VpceServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the VPC endpoint service running in your AWS account that you want Device
        /// Farm to test.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VpceServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpceConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpceConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpceConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpceConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpceConfigurationName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpceConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DFVPCEConfiguration (CreateVPCEConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse, NewDFVPCEConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpceConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ServiceDnsName = this.ServiceDnsName;
            #if MODULAR
            if (this.ServiceDnsName == null && ParameterWasBound(nameof(this.ServiceDnsName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceDnsName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpceConfigurationDescription = this.VpceConfigurationDescription;
            context.VpceConfigurationName = this.VpceConfigurationName;
            #if MODULAR
            if (this.VpceConfigurationName == null && ParameterWasBound(nameof(this.VpceConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter VpceConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpceServiceName = this.VpceServiceName;
            #if MODULAR
            if (this.VpceServiceName == null && ParameterWasBound(nameof(this.VpceServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter VpceServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DeviceFarm.Model.CreateVPCEConfigurationRequest();
            
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
        
        private Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.CreateVPCEConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "CreateVPCEConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateVPCEConfiguration(request);
                #elif CORECLR
                return client.CreateVPCEConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ServiceDnsName { get; set; }
            public System.String VpceConfigurationDescription { get; set; }
            public System.String VpceConfigurationName { get; set; }
            public System.String VpceServiceName { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.CreateVPCEConfigurationResponse, NewDFVPCEConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpceConfiguration;
        }
        
    }
}
