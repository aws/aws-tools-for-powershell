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
    /// Creates a Recycle Bin retention rule. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/recycle-bin-working-with-rules.html#recycle-bin-create-rule">
    /// Create Recycle Bin retention rules</a> in the <i>Amazon Elastic Compute Cloud User
    /// Guide</i>.
    /// </summary>
    [Cmdlet("New", "RBINRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RecycleBin.Model.CreateRuleResponse")]
    [AWSCmdlet("Calls the Amazon Recycle Bin CreateRule API operation.", Operation = new[] {"CreateRule"}, SelectReturnType = typeof(Amazon.RecycleBin.Model.CreateRuleResponse))]
    [AWSCmdletOutput("Amazon.RecycleBin.Model.CreateRuleResponse",
        "This cmdlet returns an Amazon.RecycleBin.Model.CreateRuleResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRBINRuleCmdlet : AmazonRecycleBinClientCmdlet, IExecutor
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
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>Specifies the resource tags to use to identify resources that are to be retained by
        /// a tag-level retention rule. For tag-level retention rules, only deleted resources,
        /// of the specified resource type, that have one or more of the specified tag key and
        /// value pairs are retained. If a resource is deleted, but it does not have any of the
        /// specified tag key and value pairs, it is immediately deleted without being retained
        /// by the retention rule.</para><para>You can add the same tag key and value pair to a maximum or five retention rules.</para><para>To create a Region-level retention rule, omit this parameter. A Region-level retention
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
        /// <para>The resource type to be retained by the retention rule. Currently, only Amazon EBS
        /// snapshots and EBS-backed AMIs are supported. To retain snapshots, specify <c>EBS_SNAPSHOT</c>.
        /// To retain EBS-backed AMIs, specify <c>EC2_IMAGE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? RetentionPeriod_RetentionPeriodValue { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Information about the tags to assign to the retention rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RecycleBin.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UnlockDelay_UnlockDelayUnit
        /// <summary>
        /// <para>
        /// <para>The unit of time in which to measure the unlock delay. Currently, the unlock delay
        /// can be measure only in days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LockConfiguration_UnlockDelay_UnlockDelayUnit")]
        [AWSConstantClassSource("Amazon.RecycleBin.UnlockDelayUnit")]
        public Amazon.RecycleBin.UnlockDelayUnit UnlockDelay_UnlockDelayUnit { get; set; }
        #endregion
        
        #region Parameter UnlockDelay_UnlockDelayValue
        /// <summary>
        /// <para>
        /// <para>The unlock delay period, measured in the unit specified for <b> UnlockDelayUnit</b>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LockConfiguration_UnlockDelay_UnlockDelayValue")]
        public System.Int32? UnlockDelay_UnlockDelayValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RecycleBin.Model.CreateRuleResponse).
        /// Specifying the name of a property of type Amazon.RecycleBin.Model.CreateRuleResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RBINRule (CreateRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RecycleBin.Model.CreateRuleResponse, NewRBINRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.UnlockDelay_UnlockDelayUnit = this.UnlockDelay_UnlockDelayUnit;
            context.UnlockDelay_UnlockDelayValue = this.UnlockDelay_UnlockDelayValue;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.RecycleBin.Model.ResourceTag>(this.ResourceTag);
            }
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionPeriod_RetentionPeriodUnit = this.RetentionPeriod_RetentionPeriodUnit;
            #if MODULAR
            if (this.RetentionPeriod_RetentionPeriodUnit == null && ParameterWasBound(nameof(this.RetentionPeriod_RetentionPeriodUnit)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionPeriod_RetentionPeriodUnit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionPeriod_RetentionPeriodValue = this.RetentionPeriod_RetentionPeriodValue;
            #if MODULAR
            if (this.RetentionPeriod_RetentionPeriodValue == null && ParameterWasBound(nameof(this.RetentionPeriod_RetentionPeriodValue)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionPeriod_RetentionPeriodValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RecycleBin.Model.Tag>(this.Tag);
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
            var request = new Amazon.RecycleBin.Model.CreateRuleRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate LockConfiguration
            var requestLockConfigurationIsNull = true;
            request.LockConfiguration = new Amazon.RecycleBin.Model.LockConfiguration();
            Amazon.RecycleBin.Model.UnlockDelay requestLockConfiguration_lockConfiguration_UnlockDelay = null;
            
             // populate UnlockDelay
            var requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = true;
            requestLockConfiguration_lockConfiguration_UnlockDelay = new Amazon.RecycleBin.Model.UnlockDelay();
            Amazon.RecycleBin.UnlockDelayUnit requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit = null;
            if (cmdletContext.UnlockDelay_UnlockDelayUnit != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit = cmdletContext.UnlockDelay_UnlockDelayUnit;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay.UnlockDelayUnit = requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayUnit;
                requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = false;
            }
            System.Int32? requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue = null;
            if (cmdletContext.UnlockDelay_UnlockDelayValue != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue = cmdletContext.UnlockDelay_UnlockDelayValue.Value;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue != null)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay.UnlockDelayValue = requestLockConfiguration_lockConfiguration_UnlockDelay_unlockDelay_UnlockDelayValue.Value;
                requestLockConfiguration_lockConfiguration_UnlockDelayIsNull = false;
            }
             // determine if requestLockConfiguration_lockConfiguration_UnlockDelay should be set to null
            if (requestLockConfiguration_lockConfiguration_UnlockDelayIsNull)
            {
                requestLockConfiguration_lockConfiguration_UnlockDelay = null;
            }
            if (requestLockConfiguration_lockConfiguration_UnlockDelay != null)
            {
                request.LockConfiguration.UnlockDelay = requestLockConfiguration_lockConfiguration_UnlockDelay;
                requestLockConfigurationIsNull = false;
            }
             // determine if request.LockConfiguration should be set to null
            if (requestLockConfigurationIsNull)
            {
                request.LockConfiguration = null;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.RecycleBin.Model.CreateRuleResponse CallAWSServiceOperation(IAmazonRecycleBin client, Amazon.RecycleBin.Model.CreateRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Recycle Bin", "CreateRule");
            try
            {
                #if DESKTOP
                return client.CreateRule(request);
                #elif CORECLR
                return client.CreateRuleAsync(request).GetAwaiter().GetResult();
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
            public Amazon.RecycleBin.UnlockDelayUnit UnlockDelay_UnlockDelayUnit { get; set; }
            public System.Int32? UnlockDelay_UnlockDelayValue { get; set; }
            public List<Amazon.RecycleBin.Model.ResourceTag> ResourceTag { get; set; }
            public Amazon.RecycleBin.ResourceType ResourceType { get; set; }
            public Amazon.RecycleBin.RetentionPeriodUnit RetentionPeriod_RetentionPeriodUnit { get; set; }
            public System.Int32? RetentionPeriod_RetentionPeriodValue { get; set; }
            public List<Amazon.RecycleBin.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.RecycleBin.Model.CreateRuleResponse, NewRBINRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
