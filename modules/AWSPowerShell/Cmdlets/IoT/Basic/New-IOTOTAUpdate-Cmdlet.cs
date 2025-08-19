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
using Amazon.IoT;
using Amazon.IoT.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Creates an IoT OTA update on a target group of things or groups.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">CreateOTAUpdate</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IOTOTAUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.CreateOTAUpdateResponse")]
    [AWSCmdlet("Calls the AWS IoT CreateOTAUpdate API operation.", Operation = new[] {"CreateOTAUpdate"}, SelectReturnType = typeof(Amazon.IoT.Model.CreateOTAUpdateResponse))]
    [AWSCmdletOutput("Amazon.IoT.Model.CreateOTAUpdateResponse",
        "This cmdlet returns an Amazon.IoT.Model.CreateOTAUpdateResponse object containing multiple properties."
    )]
    public partial class NewIOTOTAUpdateCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsJobAbortConfig_AbortCriteriaList
        /// <summary>
        /// <para>
        /// <para>The list of criteria that determine when and how to abort the job.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoT.Model.AwsJobAbortCriteria[] AwsJobAbortConfig_AbortCriteriaList { get; set; }
        #endregion
        
        #region Parameter AdditionalParameter
        /// <summary>
        /// <para>
        /// <para>A list of additional OTA update parameters, which are name-value pairs. They won't
        /// be sent to devices as a part of the Job document.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalParameters")]
        public System.Collections.Hashtable AdditionalParameter { get; set; }
        #endregion
        
        #region Parameter ExponentialRate_BaseRatePerMinute
        /// <summary>
        /// <para>
        /// <para>The minimum number of things that will be notified of a pending job, per minute, at
        /// the start of the job rollout. This is the initial rate of the rollout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsJobExecutionsRolloutConfig_ExponentialRate_BaseRatePerMinute")]
        public System.Int32? ExponentialRate_BaseRatePerMinute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the OTA update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AwsJobPresignedUrlConfig_ExpiresInSec
        /// <summary>
        /// <para>
        /// <para>How long (in seconds) pre-signed URLs are valid. Valid values are 60 - 3600, the default
        /// value is 1800 seconds. Pre-signed URLs are generated when a request for the job document
        /// is received.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AwsJobPresignedUrlConfig_ExpiresInSec { get; set; }
        #endregion
        
        #region Parameter File
        /// <summary>
        /// <para>
        /// <para>The files to be streamed by the OTA update.</para><para />
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
        [Alias("Files")]
        public Amazon.IoT.Model.OTAUpdateFile[] File { get; set; }
        #endregion
        
        #region Parameter ExponentialRate_IncrementFactor
        /// <summary>
        /// <para>
        /// <para>The rate of increase for a job rollout. The number of things notified is multiplied
        /// by this factor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsJobExecutionsRolloutConfig_ExponentialRate_IncrementFactor")]
        public System.Double? ExponentialRate_IncrementFactor { get; set; }
        #endregion
        
        #region Parameter AwsJobTimeoutConfig_InProgressTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time, in minutes, this device has to finish execution of this
        /// job. The timeout interval can be anywhere between 1 minute and 7 days (1 to 10080
        /// minutes). The in progress timer can't be updated and will apply to all job executions
        /// for the job. Whenever a job execution remains in the IN_PROGRESS status for longer
        /// than this interval, the job execution will fail and switch to the terminal <c>TIMED_OUT</c>
        /// status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsJobTimeoutConfig_InProgressTimeoutInMinutes")]
        public System.Int64? AwsJobTimeoutConfig_InProgressTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter AwsJobExecutionsRolloutConfig_MaximumPerMinute
        /// <summary>
        /// <para>
        /// <para>The maximum number of OTA update job executions started per minute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AwsJobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfNotifiedThing
        /// <summary>
        /// <para>
        /// <para>When this number of things have been notified, it will initiate an increase in the
        /// rollout rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_NumberOfNotifiedThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
        #endregion
        
        #region Parameter RateIncreaseCriteria_NumberOfSucceededThing
        /// <summary>
        /// <para>
        /// <para>When this number of things have succeeded in their job execution, it will initiate
        /// an increase in the rollout rate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AwsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_NumberOfSucceededThings")]
        public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
        #endregion
        
        #region Parameter OtaUpdateId
        /// <summary>
        /// <para>
        /// <para>The ID of the OTA update to be created.</para>
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
        public System.String OtaUpdateId { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used to transfer the OTA update image. Valid values are [HTTP], [MQTT],
        /// [HTTP, MQTT]. When both HTTP and MQTT are specified, the target device can choose
        /// the protocol.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that grants Amazon Web Services IoT Core access to the Amazon S3, IoT
        /// jobs and Amazon Web Services Code Signing resources to create an OTA update job.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata which can be used to manage updates.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IoT.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The devices targeted to receive OTA updates.</para><para />
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
        [Alias("Targets")]
        public System.String[] Target { get; set; }
        #endregion
        
        #region Parameter TargetSelection
        /// <summary>
        /// <para>
        /// <para>Specifies whether the update will continue to run (CONTINUOUS), or will be complete
        /// after all the things specified as targets have completed the update (SNAPSHOT). If
        /// continuous, the update may also be run on a thing when a change is detected in a target.
        /// For example, an update will run on a thing when the thing is added to a target group,
        /// even after the update was completed by all things originally in the group. Valid values:
        /// CONTINUOUS | SNAPSHOT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.TargetSelection")]
        public Amazon.IoT.TargetSelection TargetSelection { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.CreateOTAUpdateResponse).
        /// Specifying the name of a property of type Amazon.IoT.Model.CreateOTAUpdateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OtaUpdateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTOTAUpdate (CreateOTAUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.CreateOTAUpdateResponse, NewIOTOTAUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalParameter != null)
            {
                context.AdditionalParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalParameter.Keys)
                {
                    context.AdditionalParameter.Add((String)hashKey, (System.String)(this.AdditionalParameter[hashKey]));
                }
            }
            if (this.AwsJobAbortConfig_AbortCriteriaList != null)
            {
                context.AwsJobAbortConfig_AbortCriteriaList = new List<Amazon.IoT.Model.AwsJobAbortCriteria>(this.AwsJobAbortConfig_AbortCriteriaList);
            }
            context.ExponentialRate_BaseRatePerMinute = this.ExponentialRate_BaseRatePerMinute;
            context.ExponentialRate_IncrementFactor = this.ExponentialRate_IncrementFactor;
            context.RateIncreaseCriteria_NumberOfNotifiedThing = this.RateIncreaseCriteria_NumberOfNotifiedThing;
            context.RateIncreaseCriteria_NumberOfSucceededThing = this.RateIncreaseCriteria_NumberOfSucceededThing;
            context.AwsJobExecutionsRolloutConfig_MaximumPerMinute = this.AwsJobExecutionsRolloutConfig_MaximumPerMinute;
            context.AwsJobPresignedUrlConfig_ExpiresInSec = this.AwsJobPresignedUrlConfig_ExpiresInSec;
            context.AwsJobTimeoutConfig_InProgressTimeoutInMinute = this.AwsJobTimeoutConfig_InProgressTimeoutInMinute;
            context.Description = this.Description;
            if (this.File != null)
            {
                context.File = new List<Amazon.IoT.Model.OTAUpdateFile>(this.File);
            }
            #if MODULAR
            if (this.File == null && ParameterWasBound(nameof(this.File)))
            {
                WriteWarning("You are passing $null as a value for parameter File which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OtaUpdateId = this.OtaUpdateId;
            #if MODULAR
            if (this.OtaUpdateId == null && ParameterWasBound(nameof(this.OtaUpdateId)))
            {
                WriteWarning("You are passing $null as a value for parameter OtaUpdateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IoT.Model.Tag>(this.Tag);
            }
            if (this.Target != null)
            {
                context.Target = new List<System.String>(this.Target);
            }
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetSelection = this.TargetSelection;
            
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
            var request = new Amazon.IoT.Model.CreateOTAUpdateRequest();
            
            if (cmdletContext.AdditionalParameter != null)
            {
                request.AdditionalParameters = cmdletContext.AdditionalParameter;
            }
            
             // populate AwsJobAbortConfig
            var requestAwsJobAbortConfigIsNull = true;
            request.AwsJobAbortConfig = new Amazon.IoT.Model.AwsJobAbortConfig();
            List<Amazon.IoT.Model.AwsJobAbortCriteria> requestAwsJobAbortConfig_awsJobAbortConfig_AbortCriteriaList = null;
            if (cmdletContext.AwsJobAbortConfig_AbortCriteriaList != null)
            {
                requestAwsJobAbortConfig_awsJobAbortConfig_AbortCriteriaList = cmdletContext.AwsJobAbortConfig_AbortCriteriaList;
            }
            if (requestAwsJobAbortConfig_awsJobAbortConfig_AbortCriteriaList != null)
            {
                request.AwsJobAbortConfig.AbortCriteriaList = requestAwsJobAbortConfig_awsJobAbortConfig_AbortCriteriaList;
                requestAwsJobAbortConfigIsNull = false;
            }
             // determine if request.AwsJobAbortConfig should be set to null
            if (requestAwsJobAbortConfigIsNull)
            {
                request.AwsJobAbortConfig = null;
            }
            
             // populate AwsJobExecutionsRolloutConfig
            var requestAwsJobExecutionsRolloutConfigIsNull = true;
            request.AwsJobExecutionsRolloutConfig = new Amazon.IoT.Model.AwsJobExecutionsRolloutConfig();
            System.Int32? requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_MaximumPerMinute = null;
            if (cmdletContext.AwsJobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_MaximumPerMinute = cmdletContext.AwsJobExecutionsRolloutConfig_MaximumPerMinute.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_MaximumPerMinute != null)
            {
                request.AwsJobExecutionsRolloutConfig.MaximumPerMinute = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_MaximumPerMinute.Value;
                requestAwsJobExecutionsRolloutConfigIsNull = false;
            }
            Amazon.IoT.Model.AwsJobExponentialRolloutRate requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate = null;
            
             // populate ExponentialRate
            var requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRateIsNull = true;
            requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate = new Amazon.IoT.Model.AwsJobExponentialRolloutRate();
            System.Int32? requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute = null;
            if (cmdletContext.ExponentialRate_BaseRatePerMinute != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute = cmdletContext.ExponentialRate_BaseRatePerMinute.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate.BaseRatePerMinute = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_BaseRatePerMinute.Value;
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
            System.Double? requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor = null;
            if (cmdletContext.ExponentialRate_IncrementFactor != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor = cmdletContext.ExponentialRate_IncrementFactor.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate.IncrementFactor = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_exponentialRate_IncrementFactor.Value;
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
            Amazon.IoT.Model.AwsJobRateIncreaseCriteria requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria = null;
            
             // populate RateIncreaseCriteria
            requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria = new Amazon.IoT.Model.AwsJobRateIncreaseCriteria();
            System.Int32? requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing = cmdletContext.RateIncreaseCriteria_NumberOfNotifiedThing.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria.NumberOfNotifiedThings = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfNotifiedThing.Value;
            }
            System.Int32? requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = null;
            if (cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing = cmdletContext.RateIncreaseCriteria_NumberOfSucceededThing.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria.NumberOfSucceededThings = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria_rateIncreaseCriteria_NumberOfSucceededThing.Value;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria != null)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate.RateIncreaseCriteria = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate_awsJobExecutionsRolloutConfig_ExponentialRate_RateIncreaseCriteria;
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRateIsNull = false;
            }
             // determine if requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate should be set to null
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRateIsNull)
            {
                requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate = null;
            }
            if (requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate != null)
            {
                request.AwsJobExecutionsRolloutConfig.ExponentialRate = requestAwsJobExecutionsRolloutConfig_awsJobExecutionsRolloutConfig_ExponentialRate;
                requestAwsJobExecutionsRolloutConfigIsNull = false;
            }
             // determine if request.AwsJobExecutionsRolloutConfig should be set to null
            if (requestAwsJobExecutionsRolloutConfigIsNull)
            {
                request.AwsJobExecutionsRolloutConfig = null;
            }
            
             // populate AwsJobPresignedUrlConfig
            var requestAwsJobPresignedUrlConfigIsNull = true;
            request.AwsJobPresignedUrlConfig = new Amazon.IoT.Model.AwsJobPresignedUrlConfig();
            System.Int64? requestAwsJobPresignedUrlConfig_awsJobPresignedUrlConfig_ExpiresInSec = null;
            if (cmdletContext.AwsJobPresignedUrlConfig_ExpiresInSec != null)
            {
                requestAwsJobPresignedUrlConfig_awsJobPresignedUrlConfig_ExpiresInSec = cmdletContext.AwsJobPresignedUrlConfig_ExpiresInSec.Value;
            }
            if (requestAwsJobPresignedUrlConfig_awsJobPresignedUrlConfig_ExpiresInSec != null)
            {
                request.AwsJobPresignedUrlConfig.ExpiresInSec = requestAwsJobPresignedUrlConfig_awsJobPresignedUrlConfig_ExpiresInSec.Value;
                requestAwsJobPresignedUrlConfigIsNull = false;
            }
             // determine if request.AwsJobPresignedUrlConfig should be set to null
            if (requestAwsJobPresignedUrlConfigIsNull)
            {
                request.AwsJobPresignedUrlConfig = null;
            }
            
             // populate AwsJobTimeoutConfig
            var requestAwsJobTimeoutConfigIsNull = true;
            request.AwsJobTimeoutConfig = new Amazon.IoT.Model.AwsJobTimeoutConfig();
            System.Int64? requestAwsJobTimeoutConfig_awsJobTimeoutConfig_InProgressTimeoutInMinute = null;
            if (cmdletContext.AwsJobTimeoutConfig_InProgressTimeoutInMinute != null)
            {
                requestAwsJobTimeoutConfig_awsJobTimeoutConfig_InProgressTimeoutInMinute = cmdletContext.AwsJobTimeoutConfig_InProgressTimeoutInMinute.Value;
            }
            if (requestAwsJobTimeoutConfig_awsJobTimeoutConfig_InProgressTimeoutInMinute != null)
            {
                request.AwsJobTimeoutConfig.InProgressTimeoutInMinutes = requestAwsJobTimeoutConfig_awsJobTimeoutConfig_InProgressTimeoutInMinute.Value;
                requestAwsJobTimeoutConfigIsNull = false;
            }
             // determine if request.AwsJobTimeoutConfig should be set to null
            if (requestAwsJobTimeoutConfigIsNull)
            {
                request.AwsJobTimeoutConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.File != null)
            {
                request.Files = cmdletContext.File;
            }
            if (cmdletContext.OtaUpdateId != null)
            {
                request.OtaUpdateId = cmdletContext.OtaUpdateId;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
            }
            if (cmdletContext.TargetSelection != null)
            {
                request.TargetSelection = cmdletContext.TargetSelection;
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
        
        private Amazon.IoT.Model.CreateOTAUpdateResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.CreateOTAUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "CreateOTAUpdate");
            try
            {
                return client.CreateOTAUpdateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalParameter { get; set; }
            public List<Amazon.IoT.Model.AwsJobAbortCriteria> AwsJobAbortConfig_AbortCriteriaList { get; set; }
            public System.Int32? ExponentialRate_BaseRatePerMinute { get; set; }
            public System.Double? ExponentialRate_IncrementFactor { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfNotifiedThing { get; set; }
            public System.Int32? RateIncreaseCriteria_NumberOfSucceededThing { get; set; }
            public System.Int32? AwsJobExecutionsRolloutConfig_MaximumPerMinute { get; set; }
            public System.Int64? AwsJobPresignedUrlConfig_ExpiresInSec { get; set; }
            public System.Int64? AwsJobTimeoutConfig_InProgressTimeoutInMinute { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.IoT.Model.OTAUpdateFile> File { get; set; }
            public System.String OtaUpdateId { get; set; }
            public List<System.String> Protocol { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.IoT.Model.Tag> Tag { get; set; }
            public List<System.String> Target { get; set; }
            public Amazon.IoT.TargetSelection TargetSelection { get; set; }
            public System.Func<Amazon.IoT.Model.CreateOTAUpdateResponse, NewIOTOTAUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
