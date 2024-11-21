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
using Amazon.RecycleBin;
using Amazon.RecycleBin.Model;

namespace Amazon.PowerShell.Cmdlets.RBIN
{
    /// <summary>
    /// Updates an existing Recycle Bin retention rule. You can update a retention rule's
    /// description, resource tags, and retention period at any time after creation. You can't
    /// update a retention rule's resource type after creation. For more information, see
    /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/recycle-bin-working-with-rules.html#recycle-bin-update-rule">
    /// Update Recycle Bin retention rules</a> in the <i>Amazon Elastic Compute Cloud User
    /// Guide</i>.
    /// </summary>
    [Cmdlet("Update", "RBINRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RecycleBin.Model.UpdateRuleResponse")]
    [AWSCmdlet("Calls the Amazon Recycle Bin UpdateRule API operation.", Operation = new[] {"UpdateRule"}, SelectReturnType = typeof(Amazon.RecycleBin.Model.UpdateRuleResponse))]
    [AWSCmdletOutput("Amazon.RecycleBin.Model.UpdateRuleResponse",
        "This cmdlet returns an Amazon.RecycleBin.Model.UpdateRuleResponse object containing multiple properties."
    )]
    public partial class UpdateRBINRuleCmdlet : AmazonRecycleBinClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The retention rule description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExcludeResourceTag
        /// <summary>
        /// <para>
        /// <para>[Region-level retention rules only] Specifies the exclusion tags to use to identify
        /// resources that are to be excluded, or ignored, by a Region-level retention rule. Resources
        /// that have any of these tags are not retained by the retention rule upon deletion.</para><para>You can't specify exclusion tags for tag-level retention rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeResourceTags")]
        public Amazon.RecycleBin.Model.ResourceTag[] ExcludeResourceTag { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique ID of the retention rule.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>[Tag-level retention rules only] Specifies the resource tags to use to identify resources
        /// that are to be retained by a tag-level retention rule. For tag-level retention rules,
        /// only deleted resources, of the specified resource type, that have one or more of the
        /// specified tag key and value pairs are retained. If a resource is deleted, but it does
        /// not have any of the specified tag key and value pairs, it is immediately deleted without
        /// being retained by the retention rule.</para><para>You can add the same tag key and value pair to a maximum or five retention rules.</para><para>To create a Region-level retention rule, omit this parameter. A Region-level retention
        /// rule does not have any resource tags specified. It retains all deleted resources of
        /// the specified resource type in the Region in which the rule is created, even if the
        /// resources are not tagged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.RecycleBin.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <note><para>This parameter is currently not supported. You can't update a retention rule's resource
        /// type after creation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RecycleBin.ResourceType")]
        public Amazon.RecycleBin.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod_RetentionPeriodUnit
        /// <summary>
        /// <para>
        /// <para>The unit of time in which the retention period is measured. Currently, only <c>DAYS</c>
        /// is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RecycleBin.RetentionPeriodUnit")]
        public Amazon.RecycleBin.RetentionPeriodUnit RetentionPeriod_RetentionPeriodUnit { get; set; }
        #endregion
        
        #region Parameter RetentionPeriod_RetentionPeriodValue
        /// <summary>
        /// <para>
        /// <para>The period value for which the retention rule is to retain resources. The period is
        /// measured using the unit specified for <b>RetentionPeriodUnit</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RetentionPeriod_RetentionPeriodValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RecycleBin.Model.UpdateRuleResponse).
        /// Specifying the name of a property of type Amazon.RecycleBin.Model.UpdateRuleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RBINRule (UpdateRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RecycleBin.Model.UpdateRuleResponse, UpdateRBINRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.ExcludeResourceTag != null)
            {
                context.ExcludeResourceTag = new List<Amazon.RecycleBin.Model.ResourceTag>(this.ExcludeResourceTag);
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.RecycleBin.Model.ResourceTag>(this.ResourceTag);
            }
            context.ResourceType = this.ResourceType;
            context.RetentionPeriod_RetentionPeriodUnit = this.RetentionPeriod_RetentionPeriodUnit;
            context.RetentionPeriod_RetentionPeriodValue = this.RetentionPeriod_RetentionPeriodValue;
            
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
            var request = new Amazon.RecycleBin.Model.UpdateRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExcludeResourceTag != null)
            {
                request.ExcludeResourceTags = cmdletContext.ExcludeResourceTag;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            
             // populate RetentionPeriod
            var requestRetentionPeriodIsNull = true;
            request.RetentionPeriod = new Amazon.RecycleBin.Model.RetentionPeriod();
            Amazon.RecycleBin.RetentionPeriodUnit requestRetentionPeriod_retentionPeriod_RetentionPeriodUnit = null;
            if (cmdletContext.RetentionPeriod_RetentionPeriodUnit != null)
            {
                requestRetentionPeriod_retentionPeriod_RetentionPeriodUnit = cmdletContext.RetentionPeriod_RetentionPeriodUnit;
            }
            if (requestRetentionPeriod_retentionPeriod_RetentionPeriodUnit != null)
            {
                request.RetentionPeriod.RetentionPeriodUnit = requestRetentionPeriod_retentionPeriod_RetentionPeriodUnit;
                requestRetentionPeriodIsNull = false;
            }
            System.Int32? requestRetentionPeriod_retentionPeriod_RetentionPeriodValue = null;
            if (cmdletContext.RetentionPeriod_RetentionPeriodValue != null)
            {
                requestRetentionPeriod_retentionPeriod_RetentionPeriodValue = cmdletContext.RetentionPeriod_RetentionPeriodValue.Value;
            }
            if (requestRetentionPeriod_retentionPeriod_RetentionPeriodValue != null)
            {
                request.RetentionPeriod.RetentionPeriodValue = requestRetentionPeriod_retentionPeriod_RetentionPeriodValue.Value;
                requestRetentionPeriodIsNull = false;
            }
             // determine if request.RetentionPeriod should be set to null
            if (requestRetentionPeriodIsNull)
            {
                request.RetentionPeriod = null;
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
        
        private Amazon.RecycleBin.Model.UpdateRuleResponse CallAWSServiceOperation(IAmazonRecycleBin client, Amazon.RecycleBin.Model.UpdateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Recycle Bin", "UpdateRule");
            try
            {
                #if DESKTOP
                return client.UpdateRule(request);
                #elif CORECLR
                return client.UpdateRuleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.RecycleBin.Model.ResourceTag> ExcludeResourceTag { get; set; }
            public System.String Identifier { get; set; }
            public List<Amazon.RecycleBin.Model.ResourceTag> ResourceTag { get; set; }
            public Amazon.RecycleBin.ResourceType ResourceType { get; set; }
            public Amazon.RecycleBin.RetentionPeriodUnit RetentionPeriod_RetentionPeriodUnit { get; set; }
            public System.Int32? RetentionPeriod_RetentionPeriodValue { get; set; }
            public System.Func<Amazon.RecycleBin.Model.UpdateRuleResponse, UpdateRBINRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
