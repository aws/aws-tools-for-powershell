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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates the default settings for new user profiles in the domain.
    /// </summary>
    [Cmdlet("Update", "SMDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateDomain API operation.", Operation = new[] {"UpdateDomain"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateDomainResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateDomainResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateDomainResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMDomainCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter DefaultUserSetting
        /// <summary>
        /// <para>
        /// <para>A collection of settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DefaultUserSettings")]
        public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
        #endregion
        
        #region Parameter RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The execution role for the <code>RStudioServerPro</code> Domain-level app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn")]
        public System.String RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain to be updated.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the image version runs on.</para><note><para>JupyterServer Apps only support the <code>system</code> value. KernelGateway Apps
        /// do not support the <code>system</code> value, but support all other values for available
        /// instance types.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_InstanceType")]
        [AWSConstantClassSource("Amazon.SageMaker.AppInstanceType")]
        public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_LifecycleConfigArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the Lifecycle Configuration attached to the Resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_LifecycleConfigArn")]
        public System.String DefaultResourceSpec_LifecycleConfigArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SageMaker image that the image version belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageArn")]
        public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
        #endregion
        
        #region Parameter DefaultResourceSpec_SageMakerImageVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the image version created on the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DomainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_SageMakerImageVersionArn")]
        public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DomainArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateDomainResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateDomainResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DomainArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMDomain (UpdateDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DefaultUserSetting = this.DefaultUserSetting;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultResourceSpec_InstanceType = this.DefaultResourceSpec_InstanceType;
            context.DefaultResourceSpec_LifecycleConfigArn = this.DefaultResourceSpec_LifecycleConfigArn;
            context.DefaultResourceSpec_SageMakerImageArn = this.DefaultResourceSpec_SageMakerImageArn;
            context.DefaultResourceSpec_SageMakerImageVersionArn = this.DefaultResourceSpec_SageMakerImageVersionArn;
            context.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = this.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
            
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
            var request = new Amazon.SageMaker.Model.UpdateDomainRequest();
            
            if (cmdletContext.DefaultUserSetting != null)
            {
                request.DefaultUserSettings = cmdletContext.DefaultUserSetting;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate DomainSettingsForUpdate
            var requestDomainSettingsForUpdateIsNull = true;
            request.DomainSettingsForUpdate = new Amazon.SageMaker.Model.DomainSettingsForUpdate();
            Amazon.SageMaker.Model.RStudioServerProDomainSettingsForUpdate requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = null;
            
             // populate RStudioServerProDomainSettingsForUpdate
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = new Amazon.SageMaker.Model.RStudioServerProDomainSettingsForUpdate();
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = null;
            if (cmdletContext.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn = cmdletContext.RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.DomainExecutionRoleArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_rStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSpec requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = null;
            
             // populate DefaultResourceSpec
            var requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = true;
            requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = new Amazon.SageMaker.Model.ResourceSpec();
            Amazon.SageMaker.AppInstanceType requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType = null;
            if (cmdletContext.DefaultResourceSpec_InstanceType != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType = cmdletContext.DefaultResourceSpec_InstanceType;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.InstanceType = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_InstanceType;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = null;
            if (cmdletContext.DefaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn = cmdletContext.DefaultResourceSpec_LifecycleConfigArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.LifecycleConfigArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_LifecycleConfigArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn = cmdletContext.DefaultResourceSpec_SageMakerImageArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.SageMakerImageArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
            System.String requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = null;
            if (cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn = cmdletContext.DefaultResourceSpec_SageMakerImageVersionArn;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec.SageMakerImageVersionArn = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec_defaultResourceSpec_SageMakerImageVersionArn;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpecIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec != null)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate.DefaultResourceSpec = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate_DefaultResourceSpec;
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull = false;
            }
             // determine if requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate should be set to null
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdateIsNull)
            {
                requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate = null;
            }
            if (requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate != null)
            {
                request.DomainSettingsForUpdate.RStudioServerProDomainSettingsForUpdate = requestDomainSettingsForUpdate_domainSettingsForUpdate_RStudioServerProDomainSettingsForUpdate;
                requestDomainSettingsForUpdateIsNull = false;
            }
             // determine if request.DomainSettingsForUpdate should be set to null
            if (requestDomainSettingsForUpdateIsNull)
            {
                request.DomainSettingsForUpdate = null;
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
        
        private Amazon.SageMaker.Model.UpdateDomainResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateDomain");
            try
            {
                #if DESKTOP
                return client.UpdateDomain(request);
                #elif CORECLR
                return client.UpdateDomainAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.Model.UserSettings DefaultUserSetting { get; set; }
            public System.String DomainId { get; set; }
            public Amazon.SageMaker.AppInstanceType DefaultResourceSpec_InstanceType { get; set; }
            public System.String DefaultResourceSpec_LifecycleConfigArn { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageArn { get; set; }
            public System.String DefaultResourceSpec_SageMakerImageVersionArn { get; set; }
            public System.String RStudioServerProDomainSettingsForUpdate_DomainExecutionRoleArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateDomainResponse, UpdateSMDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DomainArn;
        }
        
    }
}
