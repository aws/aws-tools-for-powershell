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
using Amazon.FraudDetector;
using Amazon.FraudDetector.Model;

namespace Amazon.PowerShell.Cmdlets.FD
{
    /// <summary>
    /// Updates a detector version. The detector version attributes that you can update include
    /// models, external model endpoints, rules, rule execution mode, and description. You
    /// can only update a <c>DRAFT</c> detector version.
    /// </summary>
    [Cmdlet("Update", "FDDetectorVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Fraud Detector UpdateDetectorVersion API operation.", Operation = new[] {"UpdateDetectorVersion"}, SelectReturnType = typeof(Amazon.FraudDetector.Model.UpdateDetectorVersionResponse))]
    [AWSCmdletOutput("None or Amazon.FraudDetector.Model.UpdateDetectorVersionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FraudDetector.Model.UpdateDetectorVersionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFDDetectorVersionCmdlet : AmazonFraudDetectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The detector version description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The parent detector ID for the detector version you want to update.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter DetectorVersionId
        /// <summary>
        /// <para>
        /// <para>The detector version ID. </para>
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
        public System.String DetectorVersionId { get; set; }
        #endregion
        
        #region Parameter ExternalModelEndpoint
        /// <summary>
        /// <para>
        /// <para>The Amazon SageMaker model endpoints to include in the detector version.</para>
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
        [Alias("ExternalModelEndpoints")]
        public System.String[] ExternalModelEndpoint { get; set; }
        #endregion
        
        #region Parameter ModelVersion
        /// <summary>
        /// <para>
        /// <para>The model versions to include in the detector version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelVersions")]
        public Amazon.FraudDetector.Model.ModelVersion[] ModelVersion { get; set; }
        #endregion
        
        #region Parameter RuleExecutionMode
        /// <summary>
        /// <para>
        /// <para>The rule execution mode to add to the detector.</para><para>If you specify <c>FIRST_MATCHED</c>, Amazon Fraud Detector evaluates rules sequentially,
        /// first to last, stopping at the first matched rule. Amazon Fraud dectector then provides
        /// the outcomes for that single rule.</para><para>If you specifiy <c>ALL_MATCHED</c>, Amazon Fraud Detector evaluates all rules and
        /// returns the outcomes for all matched rules. You can define and edit the rule mode
        /// at the detector version level, when it is in draft status.</para><para>The default behavior is <c>FIRST_MATCHED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FraudDetector.RuleExecutionMode")]
        public Amazon.FraudDetector.RuleExecutionMode RuleExecutionMode { get; set; }
        #endregion
        
        #region Parameter Rule
        /// <summary>
        /// <para>
        /// <para>The rules to include in the detector version.</para>
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
        [Alias("Rules")]
        public Amazon.FraudDetector.Model.Rule[] Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FraudDetector.Model.UpdateDetectorVersionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DetectorVersionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DetectorVersionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DetectorVersionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorVersionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FDDetectorVersion (UpdateDetectorVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FraudDetector.Model.UpdateDetectorVersionResponse, UpdateFDDetectorVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DetectorVersionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorVersionId = this.DetectorVersionId;
            #if MODULAR
            if (this.DetectorVersionId == null && ParameterWasBound(nameof(this.DetectorVersionId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorVersionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExternalModelEndpoint != null)
            {
                context.ExternalModelEndpoint = new List<System.String>(this.ExternalModelEndpoint);
            }
            #if MODULAR
            if (this.ExternalModelEndpoint == null && ParameterWasBound(nameof(this.ExternalModelEndpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalModelEndpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ModelVersion != null)
            {
                context.ModelVersion = new List<Amazon.FraudDetector.Model.ModelVersion>(this.ModelVersion);
            }
            context.RuleExecutionMode = this.RuleExecutionMode;
            if (this.Rule != null)
            {
                context.Rule = new List<Amazon.FraudDetector.Model.Rule>(this.Rule);
            }
            #if MODULAR
            if (this.Rule == null && ParameterWasBound(nameof(this.Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FraudDetector.Model.UpdateDetectorVersionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
            }
            if (cmdletContext.DetectorVersionId != null)
            {
                request.DetectorVersionId = cmdletContext.DetectorVersionId;
            }
            if (cmdletContext.ExternalModelEndpoint != null)
            {
                request.ExternalModelEndpoints = cmdletContext.ExternalModelEndpoint;
            }
            if (cmdletContext.ModelVersion != null)
            {
                request.ModelVersions = cmdletContext.ModelVersion;
            }
            if (cmdletContext.RuleExecutionMode != null)
            {
                request.RuleExecutionMode = cmdletContext.RuleExecutionMode;
            }
            if (cmdletContext.Rule != null)
            {
                request.Rules = cmdletContext.Rule;
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
        
        private Amazon.FraudDetector.Model.UpdateDetectorVersionResponse CallAWSServiceOperation(IAmazonFraudDetector client, Amazon.FraudDetector.Model.UpdateDetectorVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Fraud Detector", "UpdateDetectorVersion");
            try
            {
                #if DESKTOP
                return client.UpdateDetectorVersion(request);
                #elif CORECLR
                return client.UpdateDetectorVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorId { get; set; }
            public System.String DetectorVersionId { get; set; }
            public List<System.String> ExternalModelEndpoint { get; set; }
            public List<Amazon.FraudDetector.Model.ModelVersion> ModelVersion { get; set; }
            public Amazon.FraudDetector.RuleExecutionMode RuleExecutionMode { get; set; }
            public List<Amazon.FraudDetector.Model.Rule> Rule { get; set; }
            public System.Func<Amazon.FraudDetector.Model.UpdateDetectorVersionResponse, UpdateFDDetectorVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
