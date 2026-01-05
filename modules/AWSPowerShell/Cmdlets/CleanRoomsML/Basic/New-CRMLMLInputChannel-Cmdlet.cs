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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Provides the information to create an ML input channel. An ML input channel is the
    /// result of a query that can be used for ML modeling.
    /// </summary>
    [Cmdlet("New", "CRMLMLInputChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML CreateMLInputChannel API operation.", Operation = new[] {"CreateMLInputChannel"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCRMLMLInputChannelCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SqlParameters_AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the analysis template within a collaboration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_AnalysisTemplateArn")]
        public System.String SqlParameters_AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter ConfiguredModelAlgorithmAssociation
        /// <summary>
        /// <para>
        /// <para>The associated configured model algorithms that are necessary to create this ML input
        /// channel.</para><para />
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
        [Alias("ConfiguredModelAlgorithmAssociations")]
        public System.String[] ConfiguredModelAlgorithmAssociation { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the ML input channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the KMS key that is used to access the input channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MembershipIdentifier
        /// <summary>
        /// <para>
        /// <para>The membership ID of the member that is creating the ML input channel.</para>
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
        public System.String MembershipIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ML input channel.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Worker_Number
        /// <summary>
        /// <para>
        /// <para>The number of compute workers that are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Number")]
        public System.Int32? Worker_Number { get; set; }
        #endregion
        
        #region Parameter SqlParameters_Parameter
        /// <summary>
        /// <para>
        /// <para>The protected query SQL parameters.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_Parameters")]
        public System.Collections.Hashtable SqlParameters_Parameter { get; set; }
        #endregion
        
        #region Parameter SqlParameters_QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to be submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_QueryString")]
        public System.String SqlParameters_QueryString { get; set; }
        #endregion
        
        #region Parameter ProtectedQueryInputParameters_ResultFormat
        /// <summary>
        /// <para>
        /// <para>The format in which the query results should be returned. If not specified, defaults
        /// to <c>CSV</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_ResultFormat")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.ResultFormat")]
        public Amazon.CleanRoomsML.ResultFormat ProtectedQueryInputParameters_ResultFormat { get; set; }
        #endregion
        
        #region Parameter RetentionInDay
        /// <summary>
        /// <para>
        /// <para>The number of days that the data in the ML input channel is retained.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetentionInDays")]
        public System.Int32? RetentionInDay { get; set; }
        #endregion
        
        #region Parameter InputChannel_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role used to run the query specified in the
        /// <c>dataSource</c> field of the input channel.</para><para>Passing a role across AWS accounts is not allowed. If you pass a role that isn't in
        /// your account, you get an <c>AccessDeniedException</c> error.</para>
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
        public System.String InputChannel_RoleArn { get; set; }
        #endregion
        
        #region Parameter InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark
        /// <summary>
        /// <para>
        /// <para>The Spark configuration properties for SQL workloads. This map contains key-value
        /// pairs that configure Apache Spark settings to optimize performance for your data processing
        /// jobs. You can specify up to 50 Spark properties, with each key being 1-200 characters
        /// and each value being 0-500 characters. These properties allow you to adjust compute
        /// capacity for large datasets and complex workloads.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the resource to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use aws:, AWS:, or any upper or lowercase combination of such as a prefix for
        /// keys as it is reserved for AWS use. You cannot edit or delete tag keys with this prefix.
        /// Values can have this prefix. If a tag value has aws as its prefix but the key does
        /// not, then Clean Rooms ML considers it to be a user tag and will count against the
        /// limit of 50 tags. Tags with only the key prefix of aws do not count against your tags
        /// per resource limit.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Worker_Type
        /// <summary>
        /// <para>
        /// <para>The instance type of the compute workers that are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Type")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.WorkerComputeType")]
        public Amazon.CleanRoomsML.WorkerComputeType Worker_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MlInputChannelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MlInputChannelArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRMLMLInputChannel (CreateMLInputChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse, NewCRMLMLInputChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ConfiguredModelAlgorithmAssociation != null)
            {
                context.ConfiguredModelAlgorithmAssociation = new List<System.String>(this.ConfiguredModelAlgorithmAssociation);
            }
            #if MODULAR
            if (this.ConfiguredModelAlgorithmAssociation == null && ParameterWasBound(nameof(this.ConfiguredModelAlgorithmAssociation)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredModelAlgorithmAssociation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Worker_Number = this.Worker_Number;
            if (this.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark != null)
            {
                context.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark.Keys)
                {
                    context.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark.Add((String)hashKey, (System.String)(this.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark[hashKey]));
                }
            }
            context.Worker_Type = this.Worker_Type;
            context.ProtectedQueryInputParameters_ResultFormat = this.ProtectedQueryInputParameters_ResultFormat;
            context.SqlParameters_AnalysisTemplateArn = this.SqlParameters_AnalysisTemplateArn;
            if (this.SqlParameters_Parameter != null)
            {
                context.SqlParameters_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SqlParameters_Parameter.Keys)
                {
                    context.SqlParameters_Parameter.Add((String)hashKey, (System.String)(this.SqlParameters_Parameter[hashKey]));
                }
            }
            context.SqlParameters_QueryString = this.SqlParameters_QueryString;
            context.InputChannel_RoleArn = this.InputChannel_RoleArn;
            #if MODULAR
            if (this.InputChannel_RoleArn == null && ParameterWasBound(nameof(this.InputChannel_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InputChannel_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyArn = this.KmsKeyArn;
            context.MembershipIdentifier = this.MembershipIdentifier;
            #if MODULAR
            if (this.MembershipIdentifier == null && ParameterWasBound(nameof(this.MembershipIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MembershipIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RetentionInDay = this.RetentionInDay;
            #if MODULAR
            if (this.RetentionInDay == null && ParameterWasBound(nameof(this.RetentionInDay)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionInDay which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CleanRoomsML.Model.CreateMLInputChannelRequest();
            
            if (cmdletContext.ConfiguredModelAlgorithmAssociation != null)
            {
                request.ConfiguredModelAlgorithmAssociations = cmdletContext.ConfiguredModelAlgorithmAssociation;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate InputChannel
            var requestInputChannelIsNull = true;
            request.InputChannel = new Amazon.CleanRoomsML.Model.InputChannel();
            System.String requestInputChannel_inputChannel_RoleArn = null;
            if (cmdletContext.InputChannel_RoleArn != null)
            {
                requestInputChannel_inputChannel_RoleArn = cmdletContext.InputChannel_RoleArn;
            }
            if (requestInputChannel_inputChannel_RoleArn != null)
            {
                request.InputChannel.RoleArn = requestInputChannel_inputChannel_RoleArn;
                requestInputChannelIsNull = false;
            }
            Amazon.CleanRoomsML.Model.InputChannelDataSource requestInputChannel_inputChannel_DataSource = null;
            
             // populate DataSource
            var requestInputChannel_inputChannel_DataSourceIsNull = true;
            requestInputChannel_inputChannel_DataSource = new Amazon.CleanRoomsML.Model.InputChannelDataSource();
            Amazon.CleanRoomsML.Model.ProtectedQueryInputParameters requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters = null;
            
             // populate ProtectedQueryInputParameters
            var requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParametersIsNull = true;
            requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters = new Amazon.CleanRoomsML.Model.ProtectedQueryInputParameters();
            Amazon.CleanRoomsML.ResultFormat requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_protectedQueryInputParameters_ResultFormat = null;
            if (cmdletContext.ProtectedQueryInputParameters_ResultFormat != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_protectedQueryInputParameters_ResultFormat = cmdletContext.ProtectedQueryInputParameters_ResultFormat;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_protectedQueryInputParameters_ResultFormat != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters.ResultFormat = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_protectedQueryInputParameters_ResultFormat;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParametersIsNull = false;
            }
            Amazon.CleanRoomsML.Model.ComputeConfiguration requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration = null;
            
             // populate ComputeConfiguration
            var requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfigurationIsNull = true;
            requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration = new Amazon.CleanRoomsML.Model.ComputeConfiguration();
            Amazon.CleanRoomsML.Model.WorkerComputeConfiguration requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker = null;
            
             // populate Worker
            var requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_WorkerIsNull = true;
            requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker = new Amazon.CleanRoomsML.Model.WorkerComputeConfiguration();
            System.Int32? requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Number = null;
            if (cmdletContext.Worker_Number != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Number = cmdletContext.Worker_Number.Value;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Number != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker.Number = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Number.Value;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_WorkerIsNull = false;
            }
            Amazon.CleanRoomsML.WorkerComputeType requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Type = null;
            if (cmdletContext.Worker_Type != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Type = cmdletContext.Worker_Type;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Type != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker.Type = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_worker_Type;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_WorkerIsNull = false;
            }
            Amazon.CleanRoomsML.Model.WorkerComputeConfigurationProperties requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties = null;
            
             // populate Properties
            var requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_PropertiesIsNull = true;
            requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties = new Amazon.CleanRoomsML.Model.WorkerComputeConfigurationProperties();
            Dictionary<System.String, System.String> requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark = null;
            if (cmdletContext.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark = cmdletContext.InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties.Spark = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_PropertiesIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties should be set to null
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_PropertiesIsNull)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties = null;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker.Properties = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_WorkerIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker should be set to null
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_WorkerIsNull)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker = null;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration.Worker = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfigurationIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration should be set to null
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfigurationIsNull)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration = null;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters.ComputeConfiguration = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParametersIsNull = false;
            }
            Amazon.CleanRoomsML.Model.ProtectedQuerySQLParameters requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters = null;
            
             // populate SqlParameters
            var requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParametersIsNull = true;
            requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters = new Amazon.CleanRoomsML.Model.ProtectedQuerySQLParameters();
            System.String requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_AnalysisTemplateArn = null;
            if (cmdletContext.SqlParameters_AnalysisTemplateArn != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_AnalysisTemplateArn = cmdletContext.SqlParameters_AnalysisTemplateArn;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_AnalysisTemplateArn != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters.AnalysisTemplateArn = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_AnalysisTemplateArn;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_Parameter = null;
            if (cmdletContext.SqlParameters_Parameter != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_Parameter = cmdletContext.SqlParameters_Parameter;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_Parameter != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters.Parameters = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_Parameter;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParametersIsNull = false;
            }
            System.String requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_QueryString = null;
            if (cmdletContext.SqlParameters_QueryString != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_QueryString = cmdletContext.SqlParameters_QueryString;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_QueryString != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters.QueryString = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters_sqlParameters_QueryString;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParametersIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters should be set to null
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParametersIsNull)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters = null;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters != null)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters.SqlParameters = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters_inputChannel_DataSource_ProtectedQueryInputParameters_SqlParameters;
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParametersIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters should be set to null
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParametersIsNull)
            {
                requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters = null;
            }
            if (requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters != null)
            {
                requestInputChannel_inputChannel_DataSource.ProtectedQueryInputParameters = requestInputChannel_inputChannel_DataSource_inputChannel_DataSource_ProtectedQueryInputParameters;
                requestInputChannel_inputChannel_DataSourceIsNull = false;
            }
             // determine if requestInputChannel_inputChannel_DataSource should be set to null
            if (requestInputChannel_inputChannel_DataSourceIsNull)
            {
                requestInputChannel_inputChannel_DataSource = null;
            }
            if (requestInputChannel_inputChannel_DataSource != null)
            {
                request.InputChannel.DataSource = requestInputChannel_inputChannel_DataSource;
                requestInputChannelIsNull = false;
            }
             // determine if request.InputChannel should be set to null
            if (requestInputChannelIsNull)
            {
                request.InputChannel = null;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.MembershipIdentifier != null)
            {
                request.MembershipIdentifier = cmdletContext.MembershipIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RetentionInDay != null)
            {
                request.RetentionInDays = cmdletContext.RetentionInDay.Value;
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
        
        private Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.CreateMLInputChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "CreateMLInputChannel");
            try
            {
                return client.CreateMLInputChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ConfiguredModelAlgorithmAssociation { get; set; }
            public System.String Description { get; set; }
            public System.Int32? Worker_Number { get; set; }
            public Dictionary<System.String, System.String> InputChannel_DataSource_ProtectedQueryInputParameters_ComputeConfiguration_Worker_Properties_Spark { get; set; }
            public Amazon.CleanRoomsML.WorkerComputeType Worker_Type { get; set; }
            public Amazon.CleanRoomsML.ResultFormat ProtectedQueryInputParameters_ResultFormat { get; set; }
            public System.String SqlParameters_AnalysisTemplateArn { get; set; }
            public Dictionary<System.String, System.String> SqlParameters_Parameter { get; set; }
            public System.String SqlParameters_QueryString { get; set; }
            public System.String InputChannel_RoleArn { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String MembershipIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Int32? RetentionInDay { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.CreateMLInputChannelResponse, NewCRMLMLInputChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MlInputChannelArn;
        }
        
    }
}
