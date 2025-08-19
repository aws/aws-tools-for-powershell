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
using System.Threading;
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a report generator.
    /// </summary>
    [Cmdlet("New", "LICMLicenseManagerReportGenerator", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicenseManagerReportGenerator API operation.", Operation = new[] {"CreateLicenseManagerReportGenerator"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse))]
    [AWSCmdletOutput("System.String or Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLICMLicenseManagerReportGeneratorCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// on.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReportGeneratorName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to add to the report generator.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LicenseManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Type of reports to generate. The following report types an be generated:</para><ul><li><para>License configuration report - Reports the number and details of consumed licenses
        /// for a license configuration.</para></li><li><para>Resource report - Reports the tracked licenses and resource consumption for a license
        /// configuration.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LicenseManagerReportGeneratorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LicenseManagerReportGeneratorArn";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReportGeneratorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicenseManagerReportGenerator (CreateLicenseManagerReportGenerator)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse, NewLICMLicenseManagerReportGeneratorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LicenseManager.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            request.ReportFrequency = new Amazon.LicenseManager.Model.ReportFrequency();
            Amazon.LicenseManager.ReportFrequencyType requestReportFrequency_reportFrequency_Period = null;
            if (cmdletContext.ReportFrequency_Period != null)
            {
                requestReportFrequency_reportFrequency_Period = cmdletContext.ReportFrequency_Period;
            }
            if (requestReportFrequency_reportFrequency_Period != null)
            {
                request.ReportFrequency.Period = requestReportFrequency_reportFrequency_Period;
            }
            System.Int32? requestReportFrequency_reportFrequency_Value = null;
            if (cmdletContext.ReportFrequency_Value != null)
            {
                requestReportFrequency_reportFrequency_Value = cmdletContext.ReportFrequency_Value.Value;
            }
            if (requestReportFrequency_reportFrequency_Value != null)
            {
                request.ReportFrequency.Value = requestReportFrequency_reportFrequency_Value.Value;
            }
            if (cmdletContext.ReportGeneratorName != null)
            {
                request.ReportGeneratorName = cmdletContext.ReportGeneratorName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicenseManagerReportGenerator");
            try
            {
                return client.CreateLicenseManagerReportGeneratorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ReportContext_LicenseConfigurationArn { get; set; }
            public Amazon.LicenseManager.ReportFrequencyType ReportFrequency_Period { get; set; }
            public System.Int32? ReportFrequency_Value { get; set; }
            public System.String ReportGeneratorName { get; set; }
            public List<Amazon.LicenseManager.Model.Tag> Tag { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateLicenseManagerReportGeneratorResponse, NewLICMLicenseManagerReportGeneratorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LicenseManagerReportGeneratorArn;
        }
        
    }
}
