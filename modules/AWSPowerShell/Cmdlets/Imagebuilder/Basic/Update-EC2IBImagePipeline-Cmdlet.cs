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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Updates a new image pipeline. Image pipelines enable you to automate the creation
    /// and distribution of images.
    /// </summary>
    [Cmdlet("Update", "EC2IBImagePipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder UpdateImagePipeline API operation.", Operation = new[] {"UpdateImagePipeline"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.UpdateImagePipelineResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.UpdateImagePipelineResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.UpdateImagePipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEC2IBImagePipelineCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the image pipeline. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the distribution configuration that will be used
        /// to configure and distribute images updated by this image pipeline. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DistributionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter EnhancedImageMetadataEnabled
        /// <summary>
        /// <para>
        /// <para> Collects additional information about the image being created, including the operating
        /// system (OS) version and package list. This information is used to enhance the overall
        /// experience of using EC2 Image Builder. Enabled by default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
        #endregion
        
        #region Parameter ImagePipelineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the image pipeline that you want to update. </para>
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
        public System.String ImagePipelineArn { get; set; }
        #endregion
        
        #region Parameter ImageRecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the image recipe that will be used to configure
        /// images updated by this image pipeline. </para>
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
        public System.String ImageRecipeArn { get; set; }
        #endregion
        
        #region Parameter ImageTestsConfiguration_ImageTestsEnabled
        /// <summary>
        /// <para>
        /// <para>Defines if tests should be executed when building this image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageTestsConfiguration_ImageTestsEnabled { get; set; }
        #endregion
        
        #region Parameter InfrastructureConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the infrastructure configuration that will be used
        /// to build images updated by this image pipeline. </para>
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
        public System.String InfrastructureConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Schedule_PipelineExecutionStartCondition
        /// <summary>
        /// <para>
        /// <para>The condition configures when the pipeline should trigger a new image build. When
        /// the <code>pipelineExecutionStartCondition</code> is set to <code>EXPRESSION_MATCH_AND_DEPENDENCY_UPDATES_AVAILABLE</code>,
        /// and you use semantic version filters on the source image or components in your image
        /// recipe, EC2 Image Builder will build a new image only when there are new versions
        /// of the image or components in your recipe that match the semantic version filter.
        /// When it is set to <code>EXPRESSION_MATCH_ONLY</code>, it will build a new image every
        /// time the CRON expression matches the current time. For semantic version syntax, see
        /// <a href="https://docs.aws.amazon.com/imagebuilder/latest/APIReference/API_CreateComponent.html">CreateComponent</a>
        /// in the <i> EC2 Image Builder API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.PipelineExecutionStartCondition")]
        public Amazon.Imagebuilder.PipelineExecutionStartCondition Schedule_PipelineExecutionStartCondition { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The cron expression determines how often EC2 Image Builder evaluates your <code>pipelineExecutionStartCondition</code>.</para><para>For information on how to format a cron expression in Image Builder, see <a href="https://docs.aws.amazon.com/imagebuilder/latest/userguide/image-builder-cron.html">Use
        /// cron expressions in EC2 Image Builder</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the image pipeline. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.PipelineStatus")]
        public Amazon.Imagebuilder.PipelineStatus Status { get; set; }
        #endregion
        
        #region Parameter ImageTestsConfiguration_TimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum time in minutes that tests are permitted to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageTestsConfiguration_TimeoutMinutes")]
        public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token used to make this request idempotent. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImagePipelineArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.UpdateImagePipelineResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.UpdateImagePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImagePipelineArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImagePipelineArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImagePipelineArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImagePipelineArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImagePipelineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EC2IBImagePipeline (UpdateImagePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.UpdateImagePipelineResponse, UpdateEC2IBImagePipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImagePipelineArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            context.EnhancedImageMetadataEnabled = this.EnhancedImageMetadataEnabled;
            context.ImagePipelineArn = this.ImagePipelineArn;
            #if MODULAR
            if (this.ImagePipelineArn == null && ParameterWasBound(nameof(this.ImagePipelineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImagePipelineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageRecipeArn = this.ImageRecipeArn;
            #if MODULAR
            if (this.ImageRecipeArn == null && ParameterWasBound(nameof(this.ImageRecipeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageRecipeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageTestsConfiguration_ImageTestsEnabled = this.ImageTestsConfiguration_ImageTestsEnabled;
            context.ImageTestsConfiguration_TimeoutMinute = this.ImageTestsConfiguration_TimeoutMinute;
            context.InfrastructureConfigurationArn = this.InfrastructureConfigurationArn;
            #if MODULAR
            if (this.InfrastructureConfigurationArn == null && ParameterWasBound(nameof(this.InfrastructureConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_PipelineExecutionStartCondition = this.Schedule_PipelineExecutionStartCondition;
            context.Schedule_ScheduleExpression = this.Schedule_ScheduleExpression;
            context.Status = this.Status;
            
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
            var request = new Amazon.Imagebuilder.Model.UpdateImagePipelineRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
            }
            if (cmdletContext.EnhancedImageMetadataEnabled != null)
            {
                request.EnhancedImageMetadataEnabled = cmdletContext.EnhancedImageMetadataEnabled.Value;
            }
            if (cmdletContext.ImagePipelineArn != null)
            {
                request.ImagePipelineArn = cmdletContext.ImagePipelineArn;
            }
            if (cmdletContext.ImageRecipeArn != null)
            {
                request.ImageRecipeArn = cmdletContext.ImageRecipeArn;
            }
            
             // populate ImageTestsConfiguration
            var requestImageTestsConfigurationIsNull = true;
            request.ImageTestsConfiguration = new Amazon.Imagebuilder.Model.ImageTestsConfiguration();
            System.Boolean? requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled = null;
            if (cmdletContext.ImageTestsConfiguration_ImageTestsEnabled != null)
            {
                requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled = cmdletContext.ImageTestsConfiguration_ImageTestsEnabled.Value;
            }
            if (requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled != null)
            {
                request.ImageTestsConfiguration.ImageTestsEnabled = requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled.Value;
                requestImageTestsConfigurationIsNull = false;
            }
            System.Int32? requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute = null;
            if (cmdletContext.ImageTestsConfiguration_TimeoutMinute != null)
            {
                requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute = cmdletContext.ImageTestsConfiguration_TimeoutMinute.Value;
            }
            if (requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute != null)
            {
                request.ImageTestsConfiguration.TimeoutMinutes = requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute.Value;
                requestImageTestsConfigurationIsNull = false;
            }
             // determine if request.ImageTestsConfiguration should be set to null
            if (requestImageTestsConfigurationIsNull)
            {
                request.ImageTestsConfiguration = null;
            }
            if (cmdletContext.InfrastructureConfigurationArn != null)
            {
                request.InfrastructureConfigurationArn = cmdletContext.InfrastructureConfigurationArn;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.Imagebuilder.Model.Schedule();
            Amazon.Imagebuilder.PipelineExecutionStartCondition requestSchedule_schedule_PipelineExecutionStartCondition = null;
            if (cmdletContext.Schedule_PipelineExecutionStartCondition != null)
            {
                requestSchedule_schedule_PipelineExecutionStartCondition = cmdletContext.Schedule_PipelineExecutionStartCondition;
            }
            if (requestSchedule_schedule_PipelineExecutionStartCondition != null)
            {
                request.Schedule.PipelineExecutionStartCondition = requestSchedule_schedule_PipelineExecutionStartCondition;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleExpression = null;
            if (cmdletContext.Schedule_ScheduleExpression != null)
            {
                requestSchedule_schedule_ScheduleExpression = cmdletContext.Schedule_ScheduleExpression;
            }
            if (requestSchedule_schedule_ScheduleExpression != null)
            {
                request.Schedule.ScheduleExpression = requestSchedule_schedule_ScheduleExpression;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Imagebuilder.Model.UpdateImagePipelineResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.UpdateImagePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "UpdateImagePipeline");
            try
            {
                #if DESKTOP
                return client.UpdateImagePipeline(request);
                #elif CORECLR
                return client.UpdateImagePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionConfigurationArn { get; set; }
            public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
            public System.String ImagePipelineArn { get; set; }
            public System.String ImageRecipeArn { get; set; }
            public System.Boolean? ImageTestsConfiguration_ImageTestsEnabled { get; set; }
            public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
            public System.String InfrastructureConfigurationArn { get; set; }
            public Amazon.Imagebuilder.PipelineExecutionStartCondition Schedule_PipelineExecutionStartCondition { get; set; }
            public System.String Schedule_ScheduleExpression { get; set; }
            public Amazon.Imagebuilder.PipelineStatus Status { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.UpdateImagePipelineResponse, UpdateEC2IBImagePipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImagePipelineArn;
        }
        
    }
}
