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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Add or updates the evaluations for process checks. This API checks if the rule is
    /// a process check when the name of the Config rule is provided.
    /// </summary>
    [Cmdlet("Write", "CFGExternalEvaluation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Config PutExternalEvaluation API operation.", Operation = new[] {"PutExternalEvaluation"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutExternalEvaluationResponse))]
    [AWSCmdletOutput("None or Amazon.ConfigService.Model.PutExternalEvaluationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConfigService.Model.PutExternalEvaluationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGExternalEvaluationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ExternalEvaluation_Annotation
        /// <summary>
        /// <para>
        /// <para>Supplementary information about the reason of compliance. For example, this task was
        /// completed on a specific date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalEvaluation_Annotation { get; set; }
        #endregion
        
        #region Parameter ExternalEvaluation_ComplianceResourceId
        /// <summary>
        /// <para>
        /// <para>The evaluated compliance resource ID. Config accepts only Amazon Web Services account
        /// ID.</para>
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
        public System.String ExternalEvaluation_ComplianceResourceId { get; set; }
        #endregion
        
        #region Parameter ExternalEvaluation_ComplianceResourceType
        /// <summary>
        /// <para>
        /// <para>The evaluated compliance resource type. Config accepts <code>AWS::::Account</code>
        /// resource type.</para>
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
        public System.String ExternalEvaluation_ComplianceResourceType { get; set; }
        #endregion
        
        #region Parameter ExternalEvaluation_ComplianceType
        /// <summary>
        /// <para>
        /// <para>The compliance of the Amazon Web Services resource. The valid values are <code>COMPLIANT,
        /// NON_COMPLIANT, </code> and <code>NOT_APPLICABLE</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConfigService.ComplianceType")]
        public Amazon.ConfigService.ComplianceType ExternalEvaluation_ComplianceType { get; set; }
        #endregion
        
        #region Parameter ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name of the Config rule.</para>
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
        public System.String ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter ExternalEvaluation_OrderingTimestamp
        /// <summary>
        /// <para>
        /// <para>The time when the compliance was recorded. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ExternalEvaluation_OrderingTimestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutExternalEvaluationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigRuleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigRuleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGExternalEvaluation (PutExternalEvaluation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutExternalEvaluationResponse, WriteCFGExternalEvaluationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigRuleName = this.ConfigRuleName;
            #if MODULAR
            if (this.ConfigRuleName == null && ParameterWasBound(nameof(this.ConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalEvaluation_Annotation = this.ExternalEvaluation_Annotation;
            context.ExternalEvaluation_ComplianceResourceId = this.ExternalEvaluation_ComplianceResourceId;
            #if MODULAR
            if (this.ExternalEvaluation_ComplianceResourceId == null && ParameterWasBound(nameof(this.ExternalEvaluation_ComplianceResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalEvaluation_ComplianceResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalEvaluation_ComplianceResourceType = this.ExternalEvaluation_ComplianceResourceType;
            #if MODULAR
            if (this.ExternalEvaluation_ComplianceResourceType == null && ParameterWasBound(nameof(this.ExternalEvaluation_ComplianceResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalEvaluation_ComplianceResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalEvaluation_ComplianceType = this.ExternalEvaluation_ComplianceType;
            #if MODULAR
            if (this.ExternalEvaluation_ComplianceType == null && ParameterWasBound(nameof(this.ExternalEvaluation_ComplianceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalEvaluation_ComplianceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalEvaluation_OrderingTimestamp = this.ExternalEvaluation_OrderingTimestamp;
            #if MODULAR
            if (this.ExternalEvaluation_OrderingTimestamp == null && ParameterWasBound(nameof(this.ExternalEvaluation_OrderingTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalEvaluation_OrderingTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.PutExternalEvaluationRequest();
            
            if (cmdletContext.ConfigRuleName != null)
            {
                request.ConfigRuleName = cmdletContext.ConfigRuleName;
            }
            
             // populate ExternalEvaluation
            var requestExternalEvaluationIsNull = true;
            request.ExternalEvaluation = new Amazon.ConfigService.Model.ExternalEvaluation();
            System.String requestExternalEvaluation_externalEvaluation_Annotation = null;
            if (cmdletContext.ExternalEvaluation_Annotation != null)
            {
                requestExternalEvaluation_externalEvaluation_Annotation = cmdletContext.ExternalEvaluation_Annotation;
            }
            if (requestExternalEvaluation_externalEvaluation_Annotation != null)
            {
                request.ExternalEvaluation.Annotation = requestExternalEvaluation_externalEvaluation_Annotation;
                requestExternalEvaluationIsNull = false;
            }
            System.String requestExternalEvaluation_externalEvaluation_ComplianceResourceId = null;
            if (cmdletContext.ExternalEvaluation_ComplianceResourceId != null)
            {
                requestExternalEvaluation_externalEvaluation_ComplianceResourceId = cmdletContext.ExternalEvaluation_ComplianceResourceId;
            }
            if (requestExternalEvaluation_externalEvaluation_ComplianceResourceId != null)
            {
                request.ExternalEvaluation.ComplianceResourceId = requestExternalEvaluation_externalEvaluation_ComplianceResourceId;
                requestExternalEvaluationIsNull = false;
            }
            System.String requestExternalEvaluation_externalEvaluation_ComplianceResourceType = null;
            if (cmdletContext.ExternalEvaluation_ComplianceResourceType != null)
            {
                requestExternalEvaluation_externalEvaluation_ComplianceResourceType = cmdletContext.ExternalEvaluation_ComplianceResourceType;
            }
            if (requestExternalEvaluation_externalEvaluation_ComplianceResourceType != null)
            {
                request.ExternalEvaluation.ComplianceResourceType = requestExternalEvaluation_externalEvaluation_ComplianceResourceType;
                requestExternalEvaluationIsNull = false;
            }
            Amazon.ConfigService.ComplianceType requestExternalEvaluation_externalEvaluation_ComplianceType = null;
            if (cmdletContext.ExternalEvaluation_ComplianceType != null)
            {
                requestExternalEvaluation_externalEvaluation_ComplianceType = cmdletContext.ExternalEvaluation_ComplianceType;
            }
            if (requestExternalEvaluation_externalEvaluation_ComplianceType != null)
            {
                request.ExternalEvaluation.ComplianceType = requestExternalEvaluation_externalEvaluation_ComplianceType;
                requestExternalEvaluationIsNull = false;
            }
            System.DateTime? requestExternalEvaluation_externalEvaluation_OrderingTimestamp = null;
            if (cmdletContext.ExternalEvaluation_OrderingTimestamp != null)
            {
                requestExternalEvaluation_externalEvaluation_OrderingTimestamp = cmdletContext.ExternalEvaluation_OrderingTimestamp.Value;
            }
            if (requestExternalEvaluation_externalEvaluation_OrderingTimestamp != null)
            {
                request.ExternalEvaluation.OrderingTimestamp = requestExternalEvaluation_externalEvaluation_OrderingTimestamp.Value;
                requestExternalEvaluationIsNull = false;
            }
             // determine if request.ExternalEvaluation should be set to null
            if (requestExternalEvaluationIsNull)
            {
                request.ExternalEvaluation = null;
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
        
        private Amazon.ConfigService.Model.PutExternalEvaluationResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutExternalEvaluationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutExternalEvaluation");
            try
            {
                #if DESKTOP
                return client.PutExternalEvaluation(request);
                #elif CORECLR
                return client.PutExternalEvaluationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigRuleName { get; set; }
            public System.String ExternalEvaluation_Annotation { get; set; }
            public System.String ExternalEvaluation_ComplianceResourceId { get; set; }
            public System.String ExternalEvaluation_ComplianceResourceType { get; set; }
            public Amazon.ConfigService.ComplianceType ExternalEvaluation_ComplianceType { get; set; }
            public System.DateTime? ExternalEvaluation_OrderingTimestamp { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutExternalEvaluationResponse, WriteCFGExternalEvaluationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
