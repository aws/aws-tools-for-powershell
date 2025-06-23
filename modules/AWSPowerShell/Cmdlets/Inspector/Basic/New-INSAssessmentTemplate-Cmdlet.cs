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
using Amazon.Inspector;
using Amazon.Inspector.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS
{
    /// <summary>
    /// Creates an assessment template for the assessment target that is specified by the
    /// ARN of the assessment target. If the <a href="https://docs.aws.amazon.com/inspector/latest/userguide/inspector_slr.html">service-linked
    /// role</a> isn’t already registered, this action also creates and registers a service-linked
    /// role to grant Amazon Inspector access to AWS Services needed to perform security assessments.
    /// </summary>
    [Cmdlet("New", "INSAssessmentTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Inspector CreateAssessmentTemplate API operation.", Operation = new[] {"CreateAssessmentTemplate"}, SelectReturnType = typeof(Amazon.Inspector.Model.CreateAssessmentTemplateResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector.Model.CreateAssessmentTemplateResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector.Model.CreateAssessmentTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINSAssessmentTemplateCmdlet : AmazonInspectorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssessmentTargetArn
        /// <summary>
        /// <para>
        /// <para>The ARN that specifies the assessment target for which you want to create the assessment
        /// template.</para>
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
        public System.String AssessmentTargetArn { get; set; }
        #endregion
        
        #region Parameter AssessmentTemplateName
        /// <summary>
        /// <para>
        /// <para>The user-defined name that identifies the assessment template that you want to create.
        /// You can create several assessment templates for an assessment target. The names of
        /// the assessment templates that correspond to a particular assessment target must be
        /// unique.</para>
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
        public System.String AssessmentTemplateName { get; set; }
        #endregion
        
        #region Parameter DurationInSecond
        /// <summary>
        /// <para>
        /// <para>The duration of the assessment run in seconds.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DurationInSeconds")]
        public System.Int32? DurationInSecond { get; set; }
        #endregion
        
        #region Parameter RulesPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARNs that specify the rules packages that you want to attach to the assessment
        /// template.</para><para />
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
        [Alias("RulesPackageArns")]
        public System.String[] RulesPackageArn { get; set; }
        #endregion
        
        #region Parameter UserAttributesForFinding
        /// <summary>
        /// <para>
        /// <para>The user-defined attributes that are assigned to every finding that is generated by
        /// the assessment run that uses this assessment template. An attribute is a key and value
        /// pair (an <a>Attribute</a> object). Within an assessment template, each key must be
        /// unique.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserAttributesForFindings")]
        public Amazon.Inspector.Model.Attribute[] UserAttributesForFinding { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AssessmentTemplateArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector.Model.CreateAssessmentTemplateResponse).
        /// Specifying the name of a property of type Amazon.Inspector.Model.CreateAssessmentTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AssessmentTemplateArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssessmentTemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INSAssessmentTemplate (CreateAssessmentTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector.Model.CreateAssessmentTemplateResponse, NewINSAssessmentTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssessmentTargetArn = this.AssessmentTargetArn;
            #if MODULAR
            if (this.AssessmentTargetArn == null && ParameterWasBound(nameof(this.AssessmentTargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentTargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssessmentTemplateName = this.AssessmentTemplateName;
            #if MODULAR
            if (this.AssessmentTemplateName == null && ParameterWasBound(nameof(this.AssessmentTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter AssessmentTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DurationInSecond = this.DurationInSecond;
            #if MODULAR
            if (this.DurationInSecond == null && ParameterWasBound(nameof(this.DurationInSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter DurationInSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RulesPackageArn != null)
            {
                context.RulesPackageArn = new List<System.String>(this.RulesPackageArn);
            }
            #if MODULAR
            if (this.RulesPackageArn == null && ParameterWasBound(nameof(this.RulesPackageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RulesPackageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserAttributesForFinding != null)
            {
                context.UserAttributesForFinding = new List<Amazon.Inspector.Model.Attribute>(this.UserAttributesForFinding);
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
            var request = new Amazon.Inspector.Model.CreateAssessmentTemplateRequest();
            
            if (cmdletContext.AssessmentTargetArn != null)
            {
                request.AssessmentTargetArn = cmdletContext.AssessmentTargetArn;
            }
            if (cmdletContext.AssessmentTemplateName != null)
            {
                request.AssessmentTemplateName = cmdletContext.AssessmentTemplateName;
            }
            if (cmdletContext.DurationInSecond != null)
            {
                request.DurationInSeconds = cmdletContext.DurationInSecond.Value;
            }
            if (cmdletContext.RulesPackageArn != null)
            {
                request.RulesPackageArns = cmdletContext.RulesPackageArn;
            }
            if (cmdletContext.UserAttributesForFinding != null)
            {
                request.UserAttributesForFindings = cmdletContext.UserAttributesForFinding;
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
        
        private Amazon.Inspector.Model.CreateAssessmentTemplateResponse CallAWSServiceOperation(IAmazonInspector client, Amazon.Inspector.Model.CreateAssessmentTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Inspector", "CreateAssessmentTemplate");
            try
            {
                return client.CreateAssessmentTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AssessmentTargetArn { get; set; }
            public System.String AssessmentTemplateName { get; set; }
            public System.Int32? DurationInSecond { get; set; }
            public List<System.String> RulesPackageArn { get; set; }
            public List<Amazon.Inspector.Model.Attribute> UserAttributesForFinding { get; set; }
            public System.Func<Amazon.Inspector.Model.CreateAssessmentTemplateResponse, NewINSAssessmentTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AssessmentTemplateArn;
        }
        
    }
}
