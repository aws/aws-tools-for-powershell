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
    /// Creates an endpoint using the endpoint configuration specified in the request. SageMaker
    /// uses the endpoint to provision resources and deploy models. You create the endpoint
    /// configuration with the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpointConfig.html">CreateEndpointConfig</a>
    /// API. 
    /// 
    ///  
    /// <para>
    ///  Use this API to deploy models using SageMaker hosting services. 
    /// </para><para>
    /// For an example that calls this method when deploying a model to SageMaker hosting
    /// services, see the <a href="https://github.com/aws/amazon-sagemaker-examples/blob/master/sagemaker-fundamentals/create-endpoint/create_endpoint.ipynb">Create
    /// Endpoint example notebook.</a></para><note><para>
    ///  You must not delete an <code>EndpointConfig</code> that is in use by an endpoint
    /// that is live or while the <code>UpdateEndpoint</code> or <code>CreateEndpoint</code>
    /// operations are being performed on the endpoint. To update an endpoint, you must create
    /// a new <code>EndpointConfig</code>.
    /// </para></note><para>
    /// The endpoint name must be unique within an Amazon Web Services Region in your Amazon
    /// Web Services account. 
    /// </para><para>
    /// When it receives the request, SageMaker creates the endpoint, launches the resources
    /// (ML compute instances), and deploys the model(s) on them. 
    /// </para><note><para>
    /// When you call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>,
    /// a load call is made to DynamoDB to verify that your endpoint configuration exists.
    /// When you read data from a DynamoDB table supporting <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadConsistency.html"><code>Eventually Consistent Reads</code></a>, the response might not reflect the
    /// results of a recently completed write operation. The response might include some stale
    /// data. If the dependent entities are not yet in DynamoDB, this causes a validation
    /// error. If you repeat your read request after a short time, the response should return
    /// the latest data. So retry logic is recommended to handle these possible issues. We
    /// also recommend that customers call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeEndpointConfig.html">DescribeEndpointConfig</a>
    /// before calling <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>
    /// to minimize the potential impact of a DynamoDB eventually consistent read.
    /// </para></note><para>
    /// When SageMaker receives the request, it sets the endpoint status to <code>Creating</code>.
    /// After it creates the endpoint, it sets the status to <code>InService</code>. SageMaker
    /// can then process incoming requests for inferences. To check the status of an endpoint,
    /// use the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeEndpoint.html">DescribeEndpoint</a>
    /// API.
    /// </para><para>
    /// If any of the models hosted at this endpoint get model data from an Amazon S3 location,
    /// SageMaker uses Amazon Web Services Security Token Service to download model artifacts
    /// from the S3 path you provided. Amazon Web Services STS is activated in your Amazon
    /// Web Services account by default. If you previously deactivated Amazon Web Services
    /// STS for a region, you need to reactivate Amazon Web Services STS for that region.
    /// For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_enable-regions.html">Activating
    /// and Deactivating Amazon Web Services STS in an Amazon Web Services Region</a> in the
    /// <i>Amazon Web Services Identity and Access Management User Guide</i>.
    /// </para><note><para>
    ///  To add the IAM role policies for using this API operation, go to the <a href="https://console.aws.amazon.com/iam/">IAM
    /// console</a>, and choose Roles in the left navigation pane. Search the IAM role that
    /// you want to grant access to use the <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpoint.html">CreateEndpoint</a>
    /// and <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpointConfig.html">CreateEndpointConfig</a>
    /// API operations, add the following policies to the role. 
    /// </para><ul><li><para>
    /// Option 1: For a full SageMaker access, search and attach the <code>AmazonSageMakerFullAccess</code>
    /// policy.
    /// </para></li><li><para>
    /// Option 2: For granting a limited access to an IAM role, paste the following Action
    /// elements manually into the JSON file of the IAM role: 
    /// </para><para><code>"Action": ["sagemaker:CreateEndpoint", "sagemaker:CreateEndpointConfig"]</code></para><para><code>"Resource": [</code></para><para><code>"arn:aws:sagemaker:region:account-id:endpoint/endpointName"</code></para><para><code>"arn:aws:sagemaker:region:account-id:endpoint-config/endpointConfigName"</code></para><para><code>]</code></para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/api-permissions-reference.html">SageMaker
    /// API Permissions: Actions, Permissions, and Resources Reference</a>.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "SMEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateEndpoint API operation.", Operation = new[] {"CreateEndpoint"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMEndpointCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        #region Parameter AutoRollbackConfiguration_Alarm
        /// <summary>
        /// <para>
        /// <para>List of CloudWatch alarms in your account that are configured to monitor metrics on
        /// an endpoint. If any alarms are tripped during a deployment, SageMaker rolls back the
        /// deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_AutoRollbackConfiguration_Alarms")]
        public Amazon.SageMaker.Model.Alarm[] AutoRollbackConfiguration_Alarm { get; set; }
        #endregion
        
        #region Parameter EndpointConfigName
        /// <summary>
        /// <para>
        /// <para>The name of an endpoint configuration. For more information, see <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateEndpointConfig.html">CreateEndpointConfig</a>.
        /// </para>
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
        public System.String EndpointConfigName { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint.The name must be unique within an Amazon Web Services Region
        /// in your Amazon Web Services account. The name is case-insensitive in <code>CreateEndpoint</code>,
        /// but the case is preserved and must be matched in <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_runtime_InvokeEndpoint.html">InvokeEndpoint</a>.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Maximum execution timeout for the deployment. Note that the timeout value should be
        /// larger than the total waiting time specified in <code>TerminationWaitInSeconds</code>
        /// and <code>WaitIntervalInSeconds</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSeconds")]
        public System.Int32? BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter RollingUpdatePolicy_MaximumExecutionTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The time limit for the total deployment. Exceeding this limit causes a timeout.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumExecutionTimeoutInSeconds")]
        public System.Int32? RollingUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An array of key-value pairs. You can use tags to categorize your Amazon Web Services
        /// resources in different ways, for example, by purpose, owner, or environment. For more
        /// information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services Resources</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter BlueGreenUpdatePolicy_TerminationWaitInSecond
        /// <summary>
        /// <para>
        /// <para>Additional waiting time in seconds after the completion of an endpoint deployment
        /// before terminating the old endpoint fleet. Default is 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TerminationWaitInSeconds")]
        public System.Int32? BlueGreenUpdatePolicy_TerminationWaitInSecond { get; set; }
        #endregion
        
        #region Parameter CanarySize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType CanarySize_Type { get; set; }
        #endregion
        
        #region Parameter LinearStepSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType LinearStepSize_Type { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>Traffic routing strategy type.</para><ul><li><para><code>ALL_AT_ONCE</code>: Endpoint traffic shifts to the new fleet in a single step.
        /// </para></li><li><para><code>CANARY</code>: Endpoint traffic shifts to the new fleet in two steps. The first
        /// step is the canary, which is a small portion of the traffic. The second step is the
        /// remainder of the traffic. </para></li><li><para><code>LINEAR</code>: Endpoint traffic shifts to the new fleet in n steps of a configurable
        /// size. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.TrafficRoutingConfigType")]
        public Amazon.SageMaker.TrafficRoutingConfigType TrafficRoutingConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType MaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint capacity type.</para><ul><li><para><code>INSTANCE_COUNT</code>: The endpoint activates based on the number of instances.</para></li><li><para><code>CAPACITY_PERCENT</code>: The endpoint activates based on the specified percentage
        /// of capacity.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Type")]
        [AWSConstantClassSource("Amazon.SageMaker.CapacitySizeType")]
        public Amazon.SageMaker.CapacitySizeType RollbackMaximumBatchSize_Type { get; set; }
        #endregion
        
        #region Parameter CanarySize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_Value")]
        public System.Int32? CanarySize_Value { get; set; }
        #endregion
        
        #region Parameter LinearStepSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_Value")]
        public System.Int32? LinearStepSize_Value { get; set; }
        #endregion
        
        #region Parameter MaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_MaximumBatchSize_Value")]
        public System.Int32? MaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter RollbackMaximumBatchSize_Value
        /// <summary>
        /// <para>
        /// <para>Defines the capacity size, either as a number of instances or a capacity percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_Value")]
        public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
        #endregion
        
        #region Parameter TrafficRoutingConfiguration_WaitIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The waiting time (in seconds) between incremental steps to turn on traffic on the
        /// new endpoint fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_WaitIntervalInSeconds")]
        public System.Int32? TrafficRoutingConfiguration_WaitIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter RollingUpdatePolicy_WaitIntervalInSecond
        /// <summary>
        /// <para>
        /// <para>The length of the baking period, during which SageMaker monitors alarms for each batch
        /// on the new fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfig_RollingUpdatePolicy_WaitIntervalInSeconds")]
        public System.Int32? RollingUpdatePolicy_WaitIntervalInSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateEndpointResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EndpointConfigName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EndpointConfigName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointConfigName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMEndpoint (CreateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateEndpointResponse, NewSMEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EndpointConfigName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AutoRollbackConfiguration_Alarm != null)
            {
                context.AutoRollbackConfiguration_Alarm = new List<Amazon.SageMaker.Model.Alarm>(this.AutoRollbackConfiguration_Alarm);
            }
            context.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = this.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond;
            context.BlueGreenUpdatePolicy_TerminationWaitInSecond = this.BlueGreenUpdatePolicy_TerminationWaitInSecond;
            context.CanarySize_Type = this.CanarySize_Type;
            context.CanarySize_Value = this.CanarySize_Value;
            context.LinearStepSize_Type = this.LinearStepSize_Type;
            context.LinearStepSize_Value = this.LinearStepSize_Value;
            context.TrafficRoutingConfiguration_Type = this.TrafficRoutingConfiguration_Type;
            context.TrafficRoutingConfiguration_WaitIntervalInSecond = this.TrafficRoutingConfiguration_WaitIntervalInSecond;
            context.MaximumBatchSize_Type = this.MaximumBatchSize_Type;
            context.MaximumBatchSize_Value = this.MaximumBatchSize_Value;
            context.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond = this.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond;
            context.RollbackMaximumBatchSize_Type = this.RollbackMaximumBatchSize_Type;
            context.RollbackMaximumBatchSize_Value = this.RollbackMaximumBatchSize_Value;
            context.RollingUpdatePolicy_WaitIntervalInSecond = this.RollingUpdatePolicy_WaitIntervalInSecond;
            context.EndpointConfigName = this.EndpointConfigName;
            #if MODULAR
            if (this.EndpointConfigName == null && ParameterWasBound(nameof(this.EndpointConfigName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointConfigName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateEndpointRequest();
            
            
             // populate DeploymentConfig
            var requestDeploymentConfigIsNull = true;
            request.DeploymentConfig = new Amazon.SageMaker.Model.DeploymentConfig();
            Amazon.SageMaker.Model.AutoRollbackConfig requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            
             // populate AutoRollbackConfiguration
            var requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = true;
            requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = new Amazon.SageMaker.Model.AutoRollbackConfig();
            List<Amazon.SageMaker.Model.Alarm> requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = null;
            if (cmdletContext.AutoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm = cmdletContext.AutoRollbackConfiguration_Alarm;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm != null)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration.Alarms = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration_autoRollbackConfiguration_Alarm;
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration should be set to null
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfigurationIsNull)
            {
                requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration = null;
            }
            if (requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration != null)
            {
                request.DeploymentConfig.AutoRollbackConfiguration = requestDeploymentConfig_deploymentConfig_AutoRollbackConfiguration;
                requestDeploymentConfigIsNull = false;
            }
            Amazon.SageMaker.Model.BlueGreenUpdatePolicy requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = null;
            
             // populate BlueGreenUpdatePolicy
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = new Amazon.SageMaker.Model.BlueGreenUpdatePolicy();
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = null;
            if (cmdletContext.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond = cmdletContext.BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.MaximumExecutionTimeoutInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond = null;
            if (cmdletContext.BlueGreenUpdatePolicy_TerminationWaitInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond = cmdletContext.BlueGreenUpdatePolicy_TerminationWaitInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.TerminationWaitInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_blueGreenUpdatePolicy_TerminationWaitInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.TrafficRoutingConfig requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = null;
            
             // populate TrafficRoutingConfiguration
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = new Amazon.SageMaker.Model.TrafficRoutingConfig();
            Amazon.SageMaker.TrafficRoutingConfigType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type = null;
            if (cmdletContext.TrafficRoutingConfiguration_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type = cmdletContext.TrafficRoutingConfiguration_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond = null;
            if (cmdletContext.TrafficRoutingConfiguration_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond = cmdletContext.TrafficRoutingConfiguration_WaitIntervalInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.WaitIntervalInSeconds = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_trafficRoutingConfiguration_WaitIntervalInSecond.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = null;
            
             // populate CanarySize
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type = null;
            if (cmdletContext.CanarySize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type = cmdletContext.CanarySize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value = null;
            if (cmdletContext.CanarySize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value = cmdletContext.CanarySize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize.Value = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize_canarySize_Value.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.CanarySize = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_CanarySize;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = null;
            
             // populate LinearStepSize
            var requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type = null;
            if (cmdletContext.LinearStepSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type = cmdletContext.LinearStepSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize.Type = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Type;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value = null;
            if (cmdletContext.LinearStepSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value = cmdletContext.LinearStepSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize.Value = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize_linearStepSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration.LinearStepSize = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration_LinearStepSize;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfigurationIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration != null)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy.TrafficRoutingConfiguration = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy_deploymentConfig_BlueGreenUpdatePolicy_TrafficRoutingConfiguration;
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy should be set to null
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicyIsNull)
            {
                requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy = null;
            }
            if (requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy != null)
            {
                request.DeploymentConfig.BlueGreenUpdatePolicy = requestDeploymentConfig_deploymentConfig_BlueGreenUpdatePolicy;
                requestDeploymentConfigIsNull = false;
            }
            Amazon.SageMaker.Model.RollingUpdatePolicy requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = null;
            
             // populate RollingUpdatePolicy
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = new Amazon.SageMaker.Model.RollingUpdatePolicy();
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond = null;
            if (cmdletContext.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond = cmdletContext.RollingUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.MaximumExecutionTimeoutInSeconds = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_MaximumExecutionTimeoutInSecond.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond = null;
            if (cmdletContext.RollingUpdatePolicy_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond = cmdletContext.RollingUpdatePolicy_WaitIntervalInSecond.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.WaitIntervalInSeconds = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_rollingUpdatePolicy_WaitIntervalInSecond.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = null;
            
             // populate MaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type = null;
            if (cmdletContext.MaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type = cmdletContext.MaximumBatchSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize.Type = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Type;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value = null;
            if (cmdletContext.MaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value = cmdletContext.MaximumBatchSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize.Value = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize_maximumBatchSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.MaximumBatchSize = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_MaximumBatchSize;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
            Amazon.SageMaker.Model.CapacitySize requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = null;
            
             // populate RollbackMaximumBatchSize
            var requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = true;
            requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = new Amazon.SageMaker.Model.CapacitySize();
            Amazon.SageMaker.CapacitySizeType requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type = null;
            if (cmdletContext.RollbackMaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type = cmdletContext.RollbackMaximumBatchSize_Type;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize.Type = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Type;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = false;
            }
            System.Int32? requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value = null;
            if (cmdletContext.RollbackMaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value = cmdletContext.RollbackMaximumBatchSize_Value.Value;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize.Value = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize_rollbackMaximumBatchSize_Value.Value;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSizeIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize != null)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy.RollbackMaximumBatchSize = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy_deploymentConfig_RollingUpdatePolicy_RollbackMaximumBatchSize;
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull = false;
            }
             // determine if requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy should be set to null
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicyIsNull)
            {
                requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy = null;
            }
            if (requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy != null)
            {
                request.DeploymentConfig.RollingUpdatePolicy = requestDeploymentConfig_deploymentConfig_RollingUpdatePolicy;
                requestDeploymentConfigIsNull = false;
            }
             // determine if request.DeploymentConfig should be set to null
            if (requestDeploymentConfigIsNull)
            {
                request.DeploymentConfig = null;
            }
            if (cmdletContext.EndpointConfigName != null)
            {
                request.EndpointConfigName = cmdletContext.EndpointConfigName;
            }
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
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
        
        private Amazon.SageMaker.Model.CreateEndpointResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateEndpoint(request);
                #elif CORECLR
                return client.CreateEndpointAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SageMaker.Model.Alarm> AutoRollbackConfiguration_Alarm { get; set; }
            public System.Int32? BlueGreenUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
            public System.Int32? BlueGreenUpdatePolicy_TerminationWaitInSecond { get; set; }
            public Amazon.SageMaker.CapacitySizeType CanarySize_Type { get; set; }
            public System.Int32? CanarySize_Value { get; set; }
            public Amazon.SageMaker.CapacitySizeType LinearStepSize_Type { get; set; }
            public System.Int32? LinearStepSize_Value { get; set; }
            public Amazon.SageMaker.TrafficRoutingConfigType TrafficRoutingConfiguration_Type { get; set; }
            public System.Int32? TrafficRoutingConfiguration_WaitIntervalInSecond { get; set; }
            public Amazon.SageMaker.CapacitySizeType MaximumBatchSize_Type { get; set; }
            public System.Int32? MaximumBatchSize_Value { get; set; }
            public System.Int32? RollingUpdatePolicy_MaximumExecutionTimeoutInSecond { get; set; }
            public Amazon.SageMaker.CapacitySizeType RollbackMaximumBatchSize_Type { get; set; }
            public System.Int32? RollbackMaximumBatchSize_Value { get; set; }
            public System.Int32? RollingUpdatePolicy_WaitIntervalInSecond { get; set; }
            public System.String EndpointConfigName { get; set; }
            public System.String EndpointName { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateEndpointResponse, NewSMEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointArn;
        }
        
    }
}
