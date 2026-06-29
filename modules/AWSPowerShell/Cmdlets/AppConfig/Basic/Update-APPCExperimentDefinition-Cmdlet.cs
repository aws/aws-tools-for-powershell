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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Updates an experiment definition. You can update treatments, the control, audience
    /// rules, and other properties. You cannot update an experiment definition while an experiment
    /// run is active.
    /// </summary>
    [Cmdlet("Update", "APPCExperimentDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse")]
    [AWSCmdlet("Calls the AWS AppConfig UpdateExperimentDefinition API operation.", Operation = new[] {"UpdateExperimentDefinition"}, SelectReturnType = typeof(Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse object containing multiple properties."
    )]
    public partial class UpdateAPPCExperimentDefinitionCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The application ID or name.</para>
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
        public System.String ApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter Control_FlagValue_AttributeValue
        /// <summary>
        /// <para>
        /// <para>The attribute values associated with this flag value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Control_FlagValue_AttributeValues")]
        public System.Collections.Hashtable Control_FlagValue_AttributeValue { get; set; }
        #endregion
        
        #region Parameter AudienceDescription
        /// <summary>
        /// <para>
        /// <para>An updated audience description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AudienceDescription { get; set; }
        #endregion
        
        #region Parameter AudienceRule
        /// <summary>
        /// <para>
        /// <para>An updated audience rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AudienceRule { get; set; }
        #endregion
        
        #region Parameter Control_Description
        /// <summary>
        /// <para>
        /// <para>A description of the treatment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Control_Description { get; set; }
        #endregion
        
        #region Parameter Control_FlagValue_Enabled
        /// <summary>
        /// <para>
        /// <para>Whether the feature flag is enabled for this treatment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Control_FlagValue_Enabled { get; set; }
        #endregion
        
        #region Parameter ExperimentDefinitionIdentifier
        /// <summary>
        /// <para>
        /// <para>The experiment definition ID or name.</para>
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
        public System.String ExperimentDefinitionIdentifier { get; set; }
        #endregion
        
        #region Parameter Hypothesis
        /// <summary>
        /// <para>
        /// <para>An updated hypothesis.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Hypothesis { get; set; }
        #endregion
        
        #region Parameter LaunchCriterion
        /// <summary>
        /// <para>
        /// <para>Updated launch criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchCriteria")]
        public System.String LaunchCriterion { get; set; }
        #endregion
        
        #region Parameter Treatment
        /// <summary>
        /// <para>
        /// <para>An updated list of treatments.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Treatments")]
        public Amazon.AppConfig.Model.TreatmentInput[] Treatment { get; set; }
        #endregion
        
        #region Parameter Control_Weight
        /// <summary>
        /// <para>
        /// <para>The traffic allocation weight for this treatment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Control_Weight { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExperimentDefinitionIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APPCExperimentDefinition (UpdateExperimentDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse, UpdateAPPCExperimentDefinitionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationIdentifier = this.ApplicationIdentifier;
            #if MODULAR
            if (this.ApplicationIdentifier == null && ParameterWasBound(nameof(this.ApplicationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AudienceDescription = this.AudienceDescription;
            context.AudienceRule = this.AudienceRule;
            context.Control_Description = this.Control_Description;
            if (this.Control_FlagValue_AttributeValue != null)
            {
                context.Control_FlagValue_AttributeValue = new Dictionary<System.String, Amazon.AppConfig.Model.AttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Control_FlagValue_AttributeValue.Keys)
                {
                    context.Control_FlagValue_AttributeValue.Add((String)hashKey, (Amazon.AppConfig.Model.AttributeValue)(this.Control_FlagValue_AttributeValue[hashKey]));
                }
            }
            context.Control_FlagValue_Enabled = this.Control_FlagValue_Enabled;
            context.Control_Weight = this.Control_Weight;
            context.ExperimentDefinitionIdentifier = this.ExperimentDefinitionIdentifier;
            #if MODULAR
            if (this.ExperimentDefinitionIdentifier == null && ParameterWasBound(nameof(this.ExperimentDefinitionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentDefinitionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Hypothesis = this.Hypothesis;
            context.LaunchCriterion = this.LaunchCriterion;
            if (this.Treatment != null)
            {
                context.Treatment = new List<Amazon.AppConfig.Model.TreatmentInput>(this.Treatment);
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
            var request = new Amazon.AppConfig.Model.UpdateExperimentDefinitionRequest();
            
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            if (cmdletContext.AudienceDescription != null)
            {
                request.AudienceDescription = cmdletContext.AudienceDescription;
            }
            if (cmdletContext.AudienceRule != null)
            {
                request.AudienceRule = cmdletContext.AudienceRule;
            }
            
             // populate Control
            var requestControlIsNull = true;
            request.Control = new Amazon.AppConfig.Model.TreatmentInput();
            System.String requestControl_control_Description = null;
            if (cmdletContext.Control_Description != null)
            {
                requestControl_control_Description = cmdletContext.Control_Description;
            }
            if (requestControl_control_Description != null)
            {
                request.Control.Description = requestControl_control_Description;
                requestControlIsNull = false;
            }
            System.Single? requestControl_control_Weight = null;
            if (cmdletContext.Control_Weight != null)
            {
                requestControl_control_Weight = cmdletContext.Control_Weight.Value;
            }
            if (requestControl_control_Weight != null)
            {
                request.Control.Weight = requestControl_control_Weight.Value;
                requestControlIsNull = false;
            }
            Amazon.AppConfig.Model.FlagValue requestControl_control_FlagValue = null;
            
             // populate FlagValue
            var requestControl_control_FlagValueIsNull = true;
            requestControl_control_FlagValue = new Amazon.AppConfig.Model.FlagValue();
            Dictionary<System.String, Amazon.AppConfig.Model.AttributeValue> requestControl_control_FlagValue_control_FlagValue_AttributeValue = null;
            if (cmdletContext.Control_FlagValue_AttributeValue != null)
            {
                requestControl_control_FlagValue_control_FlagValue_AttributeValue = cmdletContext.Control_FlagValue_AttributeValue;
            }
            if (requestControl_control_FlagValue_control_FlagValue_AttributeValue != null)
            {
                requestControl_control_FlagValue.AttributeValues = requestControl_control_FlagValue_control_FlagValue_AttributeValue;
                requestControl_control_FlagValueIsNull = false;
            }
            System.Boolean? requestControl_control_FlagValue_control_FlagValue_Enabled = null;
            if (cmdletContext.Control_FlagValue_Enabled != null)
            {
                requestControl_control_FlagValue_control_FlagValue_Enabled = cmdletContext.Control_FlagValue_Enabled.Value;
            }
            if (requestControl_control_FlagValue_control_FlagValue_Enabled != null)
            {
                requestControl_control_FlagValue.Enabled = requestControl_control_FlagValue_control_FlagValue_Enabled.Value;
                requestControl_control_FlagValueIsNull = false;
            }
             // determine if requestControl_control_FlagValue should be set to null
            if (requestControl_control_FlagValueIsNull)
            {
                requestControl_control_FlagValue = null;
            }
            if (requestControl_control_FlagValue != null)
            {
                request.Control.FlagValue = requestControl_control_FlagValue;
                requestControlIsNull = false;
            }
             // determine if request.Control should be set to null
            if (requestControlIsNull)
            {
                request.Control = null;
            }
            if (cmdletContext.ExperimentDefinitionIdentifier != null)
            {
                request.ExperimentDefinitionIdentifier = cmdletContext.ExperimentDefinitionIdentifier;
            }
            if (cmdletContext.Hypothesis != null)
            {
                request.Hypothesis = cmdletContext.Hypothesis;
            }
            if (cmdletContext.LaunchCriterion != null)
            {
                request.LaunchCriteria = cmdletContext.LaunchCriterion;
            }
            if (cmdletContext.Treatment != null)
            {
                request.Treatments = cmdletContext.Treatment;
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
        
        private Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.UpdateExperimentDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "UpdateExperimentDefinition");
            try
            {
                return client.UpdateExperimentDefinitionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationIdentifier { get; set; }
            public System.String AudienceDescription { get; set; }
            public System.String AudienceRule { get; set; }
            public System.String Control_Description { get; set; }
            public Dictionary<System.String, Amazon.AppConfig.Model.AttributeValue> Control_FlagValue_AttributeValue { get; set; }
            public System.Boolean? Control_FlagValue_Enabled { get; set; }
            public System.Single? Control_Weight { get; set; }
            public System.String ExperimentDefinitionIdentifier { get; set; }
            public System.String Hypothesis { get; set; }
            public System.String LaunchCriterion { get; set; }
            public List<Amazon.AppConfig.Model.TreatmentInput> Treatment { get; set; }
            public System.Func<Amazon.AppConfig.Model.UpdateExperimentDefinitionResponse, UpdateAPPCExperimentDefinitionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
