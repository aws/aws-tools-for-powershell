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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Performs a recipe step within an interactive DataBrew session that's currently open.
    /// </summary>
    [Cmdlet("Send", "GDBProjectSessionAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse")]
    [AWSCmdlet("Calls the AWS Glue DataBrew SendProjectSessionAction API operation.", Operation = new[] {"SendProjectSessionAction"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse))]
    [AWSCmdletOutput("Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse",
        "This cmdlet returns an Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse object containing multiple properties."
    )]
    public partial class SendGDBProjectSessionActionCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ViewFrame_Analytic
        /// <summary>
        /// <para>
        /// <para>Controls if analytics computation is enabled or disabled. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ViewFrame_Analytics")]
        [AWSConstantClassSource("Amazon.GlueDataBrew.AnalyticsMode")]
        public Amazon.GlueDataBrew.AnalyticsMode ViewFrame_Analytic { get; set; }
        #endregion
        
        #region Parameter ClientSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for an interactive session that's currently open and ready for
        /// work. The action will be performed on this session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientSessionId { get; set; }
        #endregion
        
        #region Parameter ViewFrame_ColumnRange
        /// <summary>
        /// <para>
        /// <para>The number of columns to include in the view frame, beginning with the <c>StartColumnIndex</c>
        /// value and ignoring any columns in the <c>HiddenColumns</c> list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewFrame_ColumnRange { get; set; }
        #endregion
        
        #region Parameter RecipeStep_ConditionExpression
        /// <summary>
        /// <para>
        /// <para>One or more conditions that must be met for the recipe step to succeed.</para><note><para>All of the conditions in the array must be met. In other words, all of the conditions
        /// must be combined using a logical AND operation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecipeStep_ConditionExpressions")]
        public Amazon.GlueDataBrew.Model.ConditionExpression[] RecipeStep_ConditionExpression { get; set; }
        #endregion
        
        #region Parameter ViewFrame_HiddenColumn
        /// <summary>
        /// <para>
        /// <para>A list of columns to hide in the view frame.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ViewFrame_HiddenColumns")]
        public System.String[] ViewFrame_HiddenColumn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the project to apply the action to.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Action_Operation
        /// <summary>
        /// <para>
        /// <para>The name of a valid DataBrew transformation to be performed on the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecipeStep_Action_Operation")]
        public System.String Action_Operation { get; set; }
        #endregion
        
        #region Parameter Action_Parameter
        /// <summary>
        /// <para>
        /// <para>Contextual parameters for the transformation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecipeStep_Action_Parameters")]
        public System.Collections.Hashtable Action_Parameter { get; set; }
        #endregion
        
        #region Parameter Preview
        /// <summary>
        /// <para>
        /// <para>If true, the result of the recipe step will be returned, but not applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Preview { get; set; }
        #endregion
        
        #region Parameter ViewFrame_RowRange
        /// <summary>
        /// <para>
        /// <para>The number of rows to include in the view frame, beginning with the <c>StartRowIndex</c>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewFrame_RowRange { get; set; }
        #endregion
        
        #region Parameter ViewFrame_StartColumnIndex
        /// <summary>
        /// <para>
        /// <para>The starting index for the range of columns to return in the view frame.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewFrame_StartColumnIndex { get; set; }
        #endregion
        
        #region Parameter ViewFrame_StartRowIndex
        /// <summary>
        /// <para>
        /// <para>The starting index for the range of rows to return in the view frame.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewFrame_StartRowIndex { get; set; }
        #endregion
        
        #region Parameter StepIndex
        /// <summary>
        /// <para>
        /// <para>The index from which to preview a step. This index is used to preview the result of
        /// steps that have already been applied, so that the resulting view frame is from earlier
        /// in the view frame stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StepIndex { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-GDBProjectSessionAction (SendProjectSessionAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse, SendGDBProjectSessionActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientSessionId = this.ClientSessionId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Preview = this.Preview;
            context.Action_Operation = this.Action_Operation;
            if (this.Action_Parameter != null)
            {
                context.Action_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Action_Parameter.Keys)
                {
                    context.Action_Parameter.Add((String)hashKey, (System.String)(this.Action_Parameter[hashKey]));
                }
            }
            if (this.RecipeStep_ConditionExpression != null)
            {
                context.RecipeStep_ConditionExpression = new List<Amazon.GlueDataBrew.Model.ConditionExpression>(this.RecipeStep_ConditionExpression);
            }
            context.StepIndex = this.StepIndex;
            context.ViewFrame_Analytic = this.ViewFrame_Analytic;
            context.ViewFrame_ColumnRange = this.ViewFrame_ColumnRange;
            if (this.ViewFrame_HiddenColumn != null)
            {
                context.ViewFrame_HiddenColumn = new List<System.String>(this.ViewFrame_HiddenColumn);
            }
            context.ViewFrame_RowRange = this.ViewFrame_RowRange;
            context.ViewFrame_StartColumnIndex = this.ViewFrame_StartColumnIndex;
            context.ViewFrame_StartRowIndex = this.ViewFrame_StartRowIndex;
            
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
            var request = new Amazon.GlueDataBrew.Model.SendProjectSessionActionRequest();
            
            if (cmdletContext.ClientSessionId != null)
            {
                request.ClientSessionId = cmdletContext.ClientSessionId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Preview != null)
            {
                request.Preview = cmdletContext.Preview.Value;
            }
            
             // populate RecipeStep
            var requestRecipeStepIsNull = true;
            request.RecipeStep = new Amazon.GlueDataBrew.Model.RecipeStep();
            List<Amazon.GlueDataBrew.Model.ConditionExpression> requestRecipeStep_recipeStep_ConditionExpression = null;
            if (cmdletContext.RecipeStep_ConditionExpression != null)
            {
                requestRecipeStep_recipeStep_ConditionExpression = cmdletContext.RecipeStep_ConditionExpression;
            }
            if (requestRecipeStep_recipeStep_ConditionExpression != null)
            {
                request.RecipeStep.ConditionExpressions = requestRecipeStep_recipeStep_ConditionExpression;
                requestRecipeStepIsNull = false;
            }
            Amazon.GlueDataBrew.Model.RecipeAction requestRecipeStep_recipeStep_Action = null;
            
             // populate Action
            var requestRecipeStep_recipeStep_ActionIsNull = true;
            requestRecipeStep_recipeStep_Action = new Amazon.GlueDataBrew.Model.RecipeAction();
            System.String requestRecipeStep_recipeStep_Action_action_Operation = null;
            if (cmdletContext.Action_Operation != null)
            {
                requestRecipeStep_recipeStep_Action_action_Operation = cmdletContext.Action_Operation;
            }
            if (requestRecipeStep_recipeStep_Action_action_Operation != null)
            {
                requestRecipeStep_recipeStep_Action.Operation = requestRecipeStep_recipeStep_Action_action_Operation;
                requestRecipeStep_recipeStep_ActionIsNull = false;
            }
            Dictionary<System.String, System.String> requestRecipeStep_recipeStep_Action_action_Parameter = null;
            if (cmdletContext.Action_Parameter != null)
            {
                requestRecipeStep_recipeStep_Action_action_Parameter = cmdletContext.Action_Parameter;
            }
            if (requestRecipeStep_recipeStep_Action_action_Parameter != null)
            {
                requestRecipeStep_recipeStep_Action.Parameters = requestRecipeStep_recipeStep_Action_action_Parameter;
                requestRecipeStep_recipeStep_ActionIsNull = false;
            }
             // determine if requestRecipeStep_recipeStep_Action should be set to null
            if (requestRecipeStep_recipeStep_ActionIsNull)
            {
                requestRecipeStep_recipeStep_Action = null;
            }
            if (requestRecipeStep_recipeStep_Action != null)
            {
                request.RecipeStep.Action = requestRecipeStep_recipeStep_Action;
                requestRecipeStepIsNull = false;
            }
             // determine if request.RecipeStep should be set to null
            if (requestRecipeStepIsNull)
            {
                request.RecipeStep = null;
            }
            if (cmdletContext.StepIndex != null)
            {
                request.StepIndex = cmdletContext.StepIndex.Value;
            }
            
             // populate ViewFrame
            var requestViewFrameIsNull = true;
            request.ViewFrame = new Amazon.GlueDataBrew.Model.ViewFrame();
            Amazon.GlueDataBrew.AnalyticsMode requestViewFrame_viewFrame_Analytic = null;
            if (cmdletContext.ViewFrame_Analytic != null)
            {
                requestViewFrame_viewFrame_Analytic = cmdletContext.ViewFrame_Analytic;
            }
            if (requestViewFrame_viewFrame_Analytic != null)
            {
                request.ViewFrame.Analytics = requestViewFrame_viewFrame_Analytic;
                requestViewFrameIsNull = false;
            }
            System.Int32? requestViewFrame_viewFrame_ColumnRange = null;
            if (cmdletContext.ViewFrame_ColumnRange != null)
            {
                requestViewFrame_viewFrame_ColumnRange = cmdletContext.ViewFrame_ColumnRange.Value;
            }
            if (requestViewFrame_viewFrame_ColumnRange != null)
            {
                request.ViewFrame.ColumnRange = requestViewFrame_viewFrame_ColumnRange.Value;
                requestViewFrameIsNull = false;
            }
            List<System.String> requestViewFrame_viewFrame_HiddenColumn = null;
            if (cmdletContext.ViewFrame_HiddenColumn != null)
            {
                requestViewFrame_viewFrame_HiddenColumn = cmdletContext.ViewFrame_HiddenColumn;
            }
            if (requestViewFrame_viewFrame_HiddenColumn != null)
            {
                request.ViewFrame.HiddenColumns = requestViewFrame_viewFrame_HiddenColumn;
                requestViewFrameIsNull = false;
            }
            System.Int32? requestViewFrame_viewFrame_RowRange = null;
            if (cmdletContext.ViewFrame_RowRange != null)
            {
                requestViewFrame_viewFrame_RowRange = cmdletContext.ViewFrame_RowRange.Value;
            }
            if (requestViewFrame_viewFrame_RowRange != null)
            {
                request.ViewFrame.RowRange = requestViewFrame_viewFrame_RowRange.Value;
                requestViewFrameIsNull = false;
            }
            System.Int32? requestViewFrame_viewFrame_StartColumnIndex = null;
            if (cmdletContext.ViewFrame_StartColumnIndex != null)
            {
                requestViewFrame_viewFrame_StartColumnIndex = cmdletContext.ViewFrame_StartColumnIndex.Value;
            }
            if (requestViewFrame_viewFrame_StartColumnIndex != null)
            {
                request.ViewFrame.StartColumnIndex = requestViewFrame_viewFrame_StartColumnIndex.Value;
                requestViewFrameIsNull = false;
            }
            System.Int32? requestViewFrame_viewFrame_StartRowIndex = null;
            if (cmdletContext.ViewFrame_StartRowIndex != null)
            {
                requestViewFrame_viewFrame_StartRowIndex = cmdletContext.ViewFrame_StartRowIndex.Value;
            }
            if (requestViewFrame_viewFrame_StartRowIndex != null)
            {
                request.ViewFrame.StartRowIndex = requestViewFrame_viewFrame_StartRowIndex.Value;
                requestViewFrameIsNull = false;
            }
             // determine if request.ViewFrame should be set to null
            if (requestViewFrameIsNull)
            {
                request.ViewFrame = null;
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
        
        private Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.SendProjectSessionActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "SendProjectSessionAction");
            try
            {
                #if DESKTOP
                return client.SendProjectSessionAction(request);
                #elif CORECLR
                return client.SendProjectSessionActionAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientSessionId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? Preview { get; set; }
            public System.String Action_Operation { get; set; }
            public Dictionary<System.String, System.String> Action_Parameter { get; set; }
            public List<Amazon.GlueDataBrew.Model.ConditionExpression> RecipeStep_ConditionExpression { get; set; }
            public System.Int32? StepIndex { get; set; }
            public Amazon.GlueDataBrew.AnalyticsMode ViewFrame_Analytic { get; set; }
            public System.Int32? ViewFrame_ColumnRange { get; set; }
            public List<System.String> ViewFrame_HiddenColumn { get; set; }
            public System.Int32? ViewFrame_RowRange { get; set; }
            public System.Int32? ViewFrame_StartColumnIndex { get; set; }
            public System.Int32? ViewFrame_StartRowIndex { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.SendProjectSessionActionResponse, SendGDBProjectSessionActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
