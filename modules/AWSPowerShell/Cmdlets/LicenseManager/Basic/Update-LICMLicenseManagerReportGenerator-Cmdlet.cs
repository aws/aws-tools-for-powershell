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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Updates a report generator.
    /// 
    ///  
    /// <para>
    /// After you make changes to a report generator, it starts generating new reports within
    /// 60 minutes of being updated.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LICMLicenseManagerReportGenerator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS License Manager UpdateLicenseManagerReportGenerator API operation.", Operation = new[] {"UpdateLicenseManagerReportGenerator"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse))]
    [AWSCmdletOutput("None or Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateLICMLicenseManagerReportGeneratorCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the report generator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ReportContext_LicenseConfigurationArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the license configuration that this generator reports
        /// on.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ReportContext_LicenseConfigurationArns")]
        public System.String[] ReportContext_LicenseConfigurationArn { get; set; }
        #endregion
        
        #region Parameter LicenseManagerReportGeneratorArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the report generator to update.</para>
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
        public System.String LicenseManagerReportGeneratorArn { get; set; }
        #endregion
        
        #region Parameter ReportFrequency_Period
        /// <summary>
        /// <para>
        /// <para>Time period between each report. The period can be daily, weekly, or monthly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.ReportFrequencyType")]
        public Amazon.LicenseManager.ReportFrequencyType ReportFrequency_Period { get; set; }
        #endregion
        
        #region Parameter ReportGeneratorName
        /// <summary>
        /// <para>
        /// <para>Name of the report generator.</para>
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
        public System.String ReportGeneratorName { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Type of reports to generate. The following report types are supported:</para><ul><li><para>License configuration report - Reports the number and details of consumed licenses
        /// for a license configuration.</para></li><li><para>Resource report - Reports the tracked licenses and resource consumption for a license
        /// configuration.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter ReportFrequency_Value
        /// <summary>
        /// <para>
        /// <para>Number of times within the frequency period that a report is generated. The only supported
        /// value is <c>1</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ReportFrequency_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LicenseManagerReportGeneratorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LicenseManagerReportGeneratorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LicenseManagerReportGeneratorArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseManagerReportGeneratorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LICMLicenseManagerReportGenerator (UpdateLicenseManagerReportGenerator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse, UpdateLICMLicenseManagerReportGeneratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LicenseManagerReportGeneratorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.LicenseManagerReportGeneratorArn = this.LicenseManagerReportGeneratorArn;
            #if MODULAR
            if (this.LicenseManagerReportGeneratorArn == null && ParameterWasBound(nameof(this.LicenseManagerReportGeneratorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseManagerReportGeneratorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReportContext_LicenseConfigurationArn != null)
            {
                context.ReportContext_LicenseConfigurationArn = new List<System.String>(this.ReportContext_LicenseConfigurationArn);
            }
            #if MODULAR
            if (this.ReportContext_LicenseConfigurationArn == null && ParameterWasBound(nameof(this.ReportContext_LicenseConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportContext_LicenseConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReportFrequency_Period = this.ReportFrequency_Period;
            context.ReportFrequency_Value = this.ReportFrequency_Value;
            context.ReportGeneratorName = this.ReportGeneratorName;
            #if MODULAR
            if (this.ReportGeneratorName == null && ParameterWasBound(nameof(this.ReportGeneratorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportGeneratorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LicenseManagerReportGeneratorArn != null)
            {
                request.LicenseManagerReportGeneratorArn = cmdletContext.LicenseManagerReportGeneratorArn;
            }
            
             // populate ReportContext
            var requestReportContextIsNull = true;
            request.ReportContext = new Amazon.LicenseManager.Model.ReportContext();
            List<System.String> requestReportContext_reportContext_LicenseConfigurationArn = null;
            if (cmdletContext.ReportContext_LicenseConfigurationArn != null)
            {
                requestReportContext_reportContext_LicenseConfigurationArn = cmdletContext.ReportContext_LicenseConfigurationArn;
            }
            if (requestReportContext_reportContext_LicenseConfigurationArn != null)
            {
                request.ReportContext.LicenseConfigurationArns = requestReportContext_reportContext_LicenseConfigurationArn;
                requestReportContextIsNull = false;
            }
             // determine if request.ReportContext should be set to null
            if (requestReportContextIsNull)
            {
                request.ReportContext = null;
            }
            
             // populate ReportFrequency
            var requestReportFrequencyIsNull = true;
            request.ReportFrequency = new Amazon.LicenseManager.Model.ReportFrequency();
            Amazon.LicenseManager.ReportFrequencyType requestReportFrequency_reportFrequency_Period = null;
            if (cmdletContext.ReportFrequency_Period != null)
            {
                requestReportFrequency_reportFrequency_Period = cmdletContext.ReportFrequency_Period;
            }
            if (requestReportFrequency_reportFrequency_Period != null)
            {
                request.ReportFrequency.Period = requestReportFrequency_reportFrequency_Period;
                requestReportFrequencyIsNull = false;
            }
            System.Int32? requestReportFrequency_reportFrequency_Value = null;
            if (cmdletContext.ReportFrequency_Value != null)
            {
                requestReportFrequency_reportFrequency_Value = cmdletContext.ReportFrequency_Value.Value;
            }
            if (requestReportFrequency_reportFrequency_Value != null)
            {
                request.ReportFrequency.Value = requestReportFrequency_reportFrequency_Value.Value;
                requestReportFrequencyIsNull = false;
            }
             // determine if request.ReportFrequency should be set to null
            if (requestReportFrequencyIsNull)
            {
                request.ReportFrequency = null;
            }
            if (cmdletContext.ReportGeneratorName != null)
            {
                request.ReportGeneratorName = cmdletContext.ReportGeneratorName;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "UpdateLicenseManagerReportGenerator");
            try
            {
                #if DESKTOP
                return client.UpdateLicenseManagerReportGenerator(request);
                #elif CORECLR
                return client.UpdateLicenseManagerReportGeneratorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String LicenseManagerReportGeneratorArn { get; set; }
            public List<System.String> ReportContext_LicenseConfigurationArn { get; set; }
            public Amazon.LicenseManager.ReportFrequencyType ReportFrequency_Period { get; set; }
            public System.Int32? ReportFrequency_Value { get; set; }
            public System.String ReportGeneratorName { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.LicenseManager.Model.UpdateLicenseManagerReportGeneratorResponse, UpdateLICMLicenseManagerReportGeneratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
