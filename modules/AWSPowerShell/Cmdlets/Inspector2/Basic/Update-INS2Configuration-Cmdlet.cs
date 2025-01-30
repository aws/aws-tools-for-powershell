/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates setting configurations for your Amazon Inspector account. When you use this
    /// API as an Amazon Inspector delegated administrator this updates the setting for all
    /// accounts you manage. Member accounts in an organization cannot update this setting.
    /// </summary>
    [Cmdlet("Update", "INS2Configuration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 UpdateConfiguration API operation.", Operation = new[] {"UpdateConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.UpdateConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.UpdateConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2ConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EcrConfiguration_PullDateRescanDuration
        /// <summary>
        /// <para>
        /// <para>The rescan duration configured for image pull date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.EcrPullDateRescanDuration")]
        public Amazon.Inspector2.EcrPullDateRescanDuration EcrConfiguration_PullDateRescanDuration { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_RescanDuration
        /// <summary>
        /// <para>
        /// <para>The rescan duration configured for image push date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Inspector2.EcrRescanDuration")]
        public Amazon.Inspector2.EcrRescanDuration EcrConfiguration_RescanDuration { get; set; }
        #endregion
        
        #region Parameter Ec2Configuration_ScanMode
        /// <summary>
        /// <para>
        /// <para>The scan method that is applied to the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.Ec2ScanMode")]
        public Amazon.Inspector2.Ec2ScanMode Ec2Configuration_ScanMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EcrConfiguration_RescanDuration parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EcrConfiguration_RescanDuration' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EcrConfiguration_RescanDuration' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EcrConfiguration_RescanDuration), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2Configuration (UpdateConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateConfigurationResponse, UpdateINS2ConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EcrConfiguration_RescanDuration;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Ec2Configuration_ScanMode = this.Ec2Configuration_ScanMode;
            context.EcrConfiguration_PullDateRescanDuration = this.EcrConfiguration_PullDateRescanDuration;
            context.EcrConfiguration_RescanDuration = this.EcrConfiguration_RescanDuration;
            
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
            var request = new Amazon.Inspector2.Model.UpdateConfigurationRequest();
            
            
             // populate Ec2Configuration
            var requestEc2ConfigurationIsNull = true;
            request.Ec2Configuration = new Amazon.Inspector2.Model.Ec2Configuration();
            Amazon.Inspector2.Ec2ScanMode requestEc2Configuration_ec2Configuration_ScanMode = null;
            if (cmdletContext.Ec2Configuration_ScanMode != null)
            {
                requestEc2Configuration_ec2Configuration_ScanMode = cmdletContext.Ec2Configuration_ScanMode;
            }
            if (requestEc2Configuration_ec2Configuration_ScanMode != null)
            {
                request.Ec2Configuration.ScanMode = requestEc2Configuration_ec2Configuration_ScanMode;
                requestEc2ConfigurationIsNull = false;
            }
             // determine if request.Ec2Configuration should be set to null
            if (requestEc2ConfigurationIsNull)
            {
                request.Ec2Configuration = null;
            }
            
             // populate EcrConfiguration
            var requestEcrConfigurationIsNull = true;
            request.EcrConfiguration = new Amazon.Inspector2.Model.EcrConfiguration();
            Amazon.Inspector2.EcrPullDateRescanDuration requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration = null;
            if (cmdletContext.EcrConfiguration_PullDateRescanDuration != null)
            {
                requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration = cmdletContext.EcrConfiguration_PullDateRescanDuration;
            }
            if (requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration != null)
            {
                request.EcrConfiguration.PullDateRescanDuration = requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration;
                requestEcrConfigurationIsNull = false;
            }
            Amazon.Inspector2.EcrRescanDuration requestEcrConfiguration_ecrConfiguration_RescanDuration = null;
            if (cmdletContext.EcrConfiguration_RescanDuration != null)
            {
                requestEcrConfiguration_ecrConfiguration_RescanDuration = cmdletContext.EcrConfiguration_RescanDuration;
            }
            if (requestEcrConfiguration_ecrConfiguration_RescanDuration != null)
            {
                request.EcrConfiguration.RescanDuration = requestEcrConfiguration_ecrConfiguration_RescanDuration;
                requestEcrConfigurationIsNull = false;
            }
             // determine if request.EcrConfiguration should be set to null
            if (requestEcrConfigurationIsNull)
            {
                request.EcrConfiguration = null;
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
        
        private Amazon.Inspector2.Model.UpdateConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateConfiguration(request);
                #elif CORECLR
                return client.UpdateConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Inspector2.Ec2ScanMode Ec2Configuration_ScanMode { get; set; }
            public Amazon.Inspector2.EcrPullDateRescanDuration EcrConfiguration_PullDateRescanDuration { get; set; }
            public Amazon.Inspector2.EcrRescanDuration EcrConfiguration_RescanDuration { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateConfigurationResponse, UpdateINS2ConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
