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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Modifies the attributes of an existing license configuration.
    /// </summary>
    [Cmdlet("Update", "LICMLicenseConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS License Manager UpdateLicenseConfiguration API operation.", Operation = new[] {"UpdateLicenseConfiguration"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateLICMLicenseConfigurationCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>New description of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisassociateWhenNotFound
        /// <summary>
        /// <para>
        /// <para>When true, disassociates a resource when software is uninstalled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisassociateWhenNotFound { get; set; }
        #endregion
        
        #region Parameter LicenseConfigurationArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the license configuration.</para>
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
        public System.String LicenseConfigurationArn { get; set; }
        #endregion
        
        #region Parameter LicenseConfigurationStatus
        /// <summary>
        /// <para>
        /// <para>New status of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.LicenseConfigurationStatus")]
        public Amazon.LicenseManager.LicenseConfigurationStatus LicenseConfigurationStatus { get; set; }
        #endregion
        
        #region Parameter LicenseCount
        /// <summary>
        /// <para>
        /// <para>New number of licenses managed by the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? LicenseCount { get; set; }
        #endregion
        
        #region Parameter LicenseCountHardLimit
        /// <summary>
        /// <para>
        /// <para>New hard limit of the number of available licenses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? LicenseCountHardLimit { get; set; }
        #endregion
        
        #region Parameter LicenseRule
        /// <summary>
        /// <para>
        /// <para>New license rule. The only rule that you can add after you create a license configuration
        /// is licenseAffinityToHost.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseRules")]
        public System.String[] LicenseRule { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>New name of the license configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProductInformationList
        /// <summary>
        /// <para>
        /// <para>New product information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LicenseManager.Model.ProductInformation[] ProductInformationList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMLicenseConfiguration (UpdateLicenseConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse, UpdateLICMLicenseConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DisassociateWhenNotFound = this.DisassociateWhenNotFound;
            context.LicenseConfigurationArn = this.LicenseConfigurationArn;
            #if MODULAR
            if (this.LicenseConfigurationArn == null && ParameterWasBound(nameof(this.LicenseConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LicenseConfigurationStatus = this.LicenseConfigurationStatus;
            context.LicenseCount = this.LicenseCount;
            context.LicenseCountHardLimit = this.LicenseCountHardLimit;
            if (this.LicenseRule != null)
            {
                context.LicenseRule = new List<System.String>(this.LicenseRule);
            }
            context.Name = this.Name;
            if (this.ProductInformationList != null)
            {
                context.ProductInformationList = new List<Amazon.LicenseManager.Model.ProductInformation>(this.ProductInformationList);
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
            var request = new Amazon.LicenseManager.Model.UpdateLicenseConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisassociateWhenNotFound != null)
            {
                request.DisassociateWhenNotFound = cmdletContext.DisassociateWhenNotFound.Value;
            }
            if (cmdletContext.LicenseConfigurationArn != null)
            {
                request.LicenseConfigurationArn = cmdletContext.LicenseConfigurationArn;
            }
            if (cmdletContext.LicenseConfigurationStatus != null)
            {
                request.LicenseConfigurationStatus = cmdletContext.LicenseConfigurationStatus;
            }
            if (cmdletContext.LicenseCount != null)
            {
                request.LicenseCount = cmdletContext.LicenseCount.Value;
            }
            if (cmdletContext.LicenseCountHardLimit != null)
            {
                request.LicenseCountHardLimit = cmdletContext.LicenseCountHardLimit.Value;
            }
            if (cmdletContext.LicenseRule != null)
            {
                request.LicenseRules = cmdletContext.LicenseRule;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProductInformationList != null)
            {
                request.ProductInformationList = cmdletContext.ProductInformationList;
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
        
        private Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.UpdateLicenseConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "UpdateLicenseConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateLicenseConfiguration(request);
                #elif CORECLR
                return client.UpdateLicenseConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? DisassociateWhenNotFound { get; set; }
            public System.String LicenseConfigurationArn { get; set; }
            public Amazon.LicenseManager.LicenseConfigurationStatus LicenseConfigurationStatus { get; set; }
            public System.Int64? LicenseCount { get; set; }
            public System.Boolean? LicenseCountHardLimit { get; set; }
            public List<System.String> LicenseRule { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.LicenseManager.Model.ProductInformation> ProductInformationList { get; set; }
            public System.Func<Amazon.LicenseManager.Model.UpdateLicenseConfigurationResponse, UpdateLICMLicenseConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
