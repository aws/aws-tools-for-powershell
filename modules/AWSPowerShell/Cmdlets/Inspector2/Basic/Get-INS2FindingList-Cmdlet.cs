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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists findings for your environment.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "INS2FindingList")]
    [OutputType("Amazon.Inspector2.Model.Finding")]
    [AWSCmdlet("Calls the Inspector2 ListFindings API operation.", Operation = new[] {"ListFindings"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListFindingsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.Finding or Amazon.Inspector2.Model.ListFindingsResponse",
        "This cmdlet returns a collection of Amazon.Inspector2.Model.Finding objects.",
        "The service call response (type Amazon.Inspector2.Model.ListFindingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINS2FindingListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterCriteria_AwsAccountId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon Web Services account IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_AwsAccountId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeRepositoryProjectName
        /// <summary>
        /// <para>
        /// <para>Filter criteria for findings based on the project name in a code repository.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeRepositoryProjectName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeRepositoryProviderType
        /// <summary>
        /// <para>
        /// <para>Filter criteria for findings based on the repository provider type (such as GitHub,
        /// GitLab, etc.).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeRepositoryProviderType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityDetectorName
        /// <summary>
        /// <para>
        /// <para>The name of the detector used to identify a code vulnerability in a Lambda function
        /// used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityDetectorName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityDetectorTag
        /// <summary>
        /// <para>
        /// <para>The detector type tag associated with the vulnerability used to filter findings. Detector
        /// tags group related vulnerabilities by common themes or tactics. For a list of available
        /// tags by programming language, see <a href="https://docs.aws.amazon.com/codeguru/detector-library/java/tags/">Java
        /// tags</a>, or <a href="https://docs.aws.amazon.com/codeguru/detector-library/python/tags/">Python
        /// tags</a>. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_CodeVulnerabilityDetectorTags")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityDetectorTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_CodeVulnerabilityFilePath
        /// <summary>
        /// <para>
        /// <para>The file path to the file in a Lambda function that contains a code vulnerability
        /// used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_CodeVulnerabilityFilePath { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ComponentId
        /// <summary>
        /// <para>
        /// <para>Details of the component IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ComponentId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ComponentType
        /// <summary>
        /// <para>
        /// <para>Details of the component types used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ComponentType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceImageId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance image IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceImageId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceSubnetId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance subnet IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceSubnetId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Ec2InstanceVpcId
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon EC2 instance VPC IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Ec2InstanceVpcId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageArchitecture
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon ECR image architecture types used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageArchitecture { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageHash
        /// <summary>
        /// <para>
        /// <para>Details of the Amazon ECR image hashes used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageHash { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageInUseCount
        /// <summary>
        /// <para>
        /// <para>Filter criteria indicating when details for an Amazon ECR image include when an Amazon
        /// ECR image is in use.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.NumberFilter[] FilterCriteria_EcrImageInUseCount { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageLastInUseAt
        /// <summary>
        /// <para>
        /// <para>Filter criteria indicating when an Amazon ECR image was last used in an Amazon ECS
        /// cluster task or Amazon EKS cluster pod.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_EcrImageLastInUseAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImagePushedAt
        /// <summary>
        /// <para>
        /// <para>Details on the Amazon ECR image push date and time used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_EcrImagePushedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageRegistry
        /// <summary>
        /// <para>
        /// <para>Details on the Amazon ECR registry used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageRegistry { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageRepositoryName
        /// <summary>
        /// <para>
        /// <para>Details on the name of the Amazon ECR repository used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageRepositoryName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EcrImageTag
        /// <summary>
        /// <para>
        /// <para>The tags attached to the Amazon ECR container image.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_EcrImageTags")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_EcrImageTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_EpssScore
        /// <summary>
        /// <para>
        /// <para>The EPSS score used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.NumberFilter[] FilterCriteria_EpssScore { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ExploitAvailable
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda findings by the availability of exploits.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ExploitAvailable { get; set; }
        #endregion
        
        #region Parameter SortCriteria_Field
        /// <summary>
        /// <para>
        /// <para>The finding detail field by which results are sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.SortField")]
        public Amazon.Inspector2.SortField SortCriteria_Field { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingArn
        /// <summary>
        /// <para>
        /// <para>Details on the finding ARNs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingStatus
        /// <summary>
        /// <para>
        /// <para>Details on the finding status types used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingStatus { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FindingType
        /// <summary>
        /// <para>
        /// <para>Details on the finding types used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FindingType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FirstObservedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was first seen used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_FirstObservedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_FixAvailable
        /// <summary>
        /// <para>
        /// <para>Details on whether a fix is available through a version update. This value can be
        /// <c>YES</c>, <c>NO</c>, or <c>PARTIAL</c>. A <c>PARTIAL</c> fix means that some, but
        /// not all, of the packages identified in the finding have fixes available through updated
        /// versions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_FixAvailable { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_InspectorScore
        /// <summary>
        /// <para>
        /// <para>The Amazon Inspector score to filter on.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.NumberFilter[] FilterCriteria_InspectorScore { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by execution role.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionLastModifiedAt
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the date and time that
        /// a user last updated the configuration, in <a href="https://www.iso.org/iso-8601-date-and-time-format.html">ISO
        /// 8601 format</a></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_LambdaFunctionLastModifiedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionLayer
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-layers.html">
        /// layers</a>. A Lambda function can have up to five layers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_LambdaFunctionLayers")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionLayer { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionName
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the name of the function.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LambdaFunctionRuntime
        /// <summary>
        /// <para>
        /// <para>Filters the list of Amazon Web Services Lambda functions by the runtime environment
        /// for the Lambda function.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_LambdaFunctionRuntime { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_LastObservedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was last seen used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_LastObservedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_NetworkProtocol
        /// <summary>
        /// <para>
        /// <para>Details on network protocol used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_NetworkProtocol { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_PortRange
        /// <summary>
        /// <para>
        /// <para>Details on the port ranges used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.PortRangeFilter[] FilterCriteria_PortRange { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_RelatedVulnerability
        /// <summary>
        /// <para>
        /// <para>Details on the related vulnerabilities used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_RelatedVulnerabilities")]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_RelatedVulnerability { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceId
        /// <summary>
        /// <para>
        /// <para>Details on the resource IDs used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ResourceId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceTag
        /// <summary>
        /// <para>
        /// <para>Details on the resource tags used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_ResourceTags")]
        public Amazon.Inspector2.Model.MapFilter[] FilterCriteria_ResourceTag { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_ResourceType
        /// <summary>
        /// <para>
        /// <para>Details on the resource types used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_ResourceType { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Severity
        /// <summary>
        /// <para>
        /// <para>Details on the severity used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Severity { get; set; }
        #endregion
        
        #region Parameter SortCriteria_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order by which findings are sorted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder SortCriteria_SortOrder { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Title
        /// <summary>
        /// <para>
        /// <para>Details on the finding title used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_Title { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_UpdatedAt
        /// <summary>
        /// <para>
        /// <para>Details on the date and time a finding was last updated at used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.DateFilter[] FilterCriteria_UpdatedAt { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VendorSeverity
        /// <summary>
        /// <para>
        /// <para>Details on the vendor severity used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VendorSeverity { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerabilityId
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerability ID used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VulnerabilityId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerabilitySource
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerability type used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Inspector2.Model.StringFilter[] FilterCriteria_VulnerabilitySource { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_VulnerablePackage
        /// <summary>
        /// <para>
        /// <para>Details on the vulnerable packages used to filter findings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_VulnerablePackages")]
        public Amazon.Inspector2.Model.PackageFilter[] FilterCriteria_VulnerablePackage { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results the response can return. If your request would return
        /// more than the maximum the response will return a <c>nextToken</c> value, use this
        /// value when you call the action again to get the remaining results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request to a list action. If your response
        /// returns more than the <c>maxResults</c> maximum value it will also return a <c>nextToken</c>
        /// value. For subsequent calls, use the <c>nextToken</c> value returned from the previous
        /// request to continue listing results after the first page.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Findings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListFindingsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListFindingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Findings";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListFindingsResponse, GetINS2FindingListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_AwsAccountId != null)
            {
                context.FilterCriteria_AwsAccountId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_AwsAccountId);
            }
            if (this.FilterCriteria_CodeRepositoryProjectName != null)
            {
                context.FilterCriteria_CodeRepositoryProjectName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeRepositoryProjectName);
            }
            if (this.FilterCriteria_CodeRepositoryProviderType != null)
            {
                context.FilterCriteria_CodeRepositoryProviderType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeRepositoryProviderType);
            }
            if (this.FilterCriteria_CodeVulnerabilityDetectorName != null)
            {
                context.FilterCriteria_CodeVulnerabilityDetectorName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityDetectorName);
            }
            if (this.FilterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                context.FilterCriteria_CodeVulnerabilityDetectorTag = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityDetectorTag);
            }
            if (this.FilterCriteria_CodeVulnerabilityFilePath != null)
            {
                context.FilterCriteria_CodeVulnerabilityFilePath = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_CodeVulnerabilityFilePath);
            }
            if (this.FilterCriteria_ComponentId != null)
            {
                context.FilterCriteria_ComponentId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ComponentId);
            }
            if (this.FilterCriteria_ComponentType != null)
            {
                context.FilterCriteria_ComponentType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ComponentType);
            }
            if (this.FilterCriteria_Ec2InstanceImageId != null)
            {
                context.FilterCriteria_Ec2InstanceImageId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceImageId);
            }
            if (this.FilterCriteria_Ec2InstanceSubnetId != null)
            {
                context.FilterCriteria_Ec2InstanceSubnetId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceSubnetId);
            }
            if (this.FilterCriteria_Ec2InstanceVpcId != null)
            {
                context.FilterCriteria_Ec2InstanceVpcId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Ec2InstanceVpcId);
            }
            if (this.FilterCriteria_EcrImageArchitecture != null)
            {
                context.FilterCriteria_EcrImageArchitecture = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageArchitecture);
            }
            if (this.FilterCriteria_EcrImageHash != null)
            {
                context.FilterCriteria_EcrImageHash = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageHash);
            }
            if (this.FilterCriteria_EcrImageInUseCount != null)
            {
                context.FilterCriteria_EcrImageInUseCount = new List<Amazon.Inspector2.Model.NumberFilter>(this.FilterCriteria_EcrImageInUseCount);
            }
            if (this.FilterCriteria_EcrImageLastInUseAt != null)
            {
                context.FilterCriteria_EcrImageLastInUseAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_EcrImageLastInUseAt);
            }
            if (this.FilterCriteria_EcrImagePushedAt != null)
            {
                context.FilterCriteria_EcrImagePushedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_EcrImagePushedAt);
            }
            if (this.FilterCriteria_EcrImageRegistry != null)
            {
                context.FilterCriteria_EcrImageRegistry = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageRegistry);
            }
            if (this.FilterCriteria_EcrImageRepositoryName != null)
            {
                context.FilterCriteria_EcrImageRepositoryName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageRepositoryName);
            }
            if (this.FilterCriteria_EcrImageTag != null)
            {
                context.FilterCriteria_EcrImageTag = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_EcrImageTag);
            }
            if (this.FilterCriteria_EpssScore != null)
            {
                context.FilterCriteria_EpssScore = new List<Amazon.Inspector2.Model.NumberFilter>(this.FilterCriteria_EpssScore);
            }
            if (this.FilterCriteria_ExploitAvailable != null)
            {
                context.FilterCriteria_ExploitAvailable = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ExploitAvailable);
            }
            if (this.FilterCriteria_FindingArn != null)
            {
                context.FilterCriteria_FindingArn = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingArn);
            }
            if (this.FilterCriteria_FindingStatus != null)
            {
                context.FilterCriteria_FindingStatus = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingStatus);
            }
            if (this.FilterCriteria_FindingType != null)
            {
                context.FilterCriteria_FindingType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FindingType);
            }
            if (this.FilterCriteria_FirstObservedAt != null)
            {
                context.FilterCriteria_FirstObservedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_FirstObservedAt);
            }
            if (this.FilterCriteria_FixAvailable != null)
            {
                context.FilterCriteria_FixAvailable = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_FixAvailable);
            }
            if (this.FilterCriteria_InspectorScore != null)
            {
                context.FilterCriteria_InspectorScore = new List<Amazon.Inspector2.Model.NumberFilter>(this.FilterCriteria_InspectorScore);
            }
            if (this.FilterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                context.FilterCriteria_LambdaFunctionExecutionRoleArn = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionExecutionRoleArn);
            }
            if (this.FilterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                context.FilterCriteria_LambdaFunctionLastModifiedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_LambdaFunctionLastModifiedAt);
            }
            if (this.FilterCriteria_LambdaFunctionLayer != null)
            {
                context.FilterCriteria_LambdaFunctionLayer = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionLayer);
            }
            if (this.FilterCriteria_LambdaFunctionName != null)
            {
                context.FilterCriteria_LambdaFunctionName = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionName);
            }
            if (this.FilterCriteria_LambdaFunctionRuntime != null)
            {
                context.FilterCriteria_LambdaFunctionRuntime = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_LambdaFunctionRuntime);
            }
            if (this.FilterCriteria_LastObservedAt != null)
            {
                context.FilterCriteria_LastObservedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_LastObservedAt);
            }
            if (this.FilterCriteria_NetworkProtocol != null)
            {
                context.FilterCriteria_NetworkProtocol = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_NetworkProtocol);
            }
            if (this.FilterCriteria_PortRange != null)
            {
                context.FilterCriteria_PortRange = new List<Amazon.Inspector2.Model.PortRangeFilter>(this.FilterCriteria_PortRange);
            }
            if (this.FilterCriteria_RelatedVulnerability != null)
            {
                context.FilterCriteria_RelatedVulnerability = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_RelatedVulnerability);
            }
            if (this.FilterCriteria_ResourceId != null)
            {
                context.FilterCriteria_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ResourceId);
            }
            if (this.FilterCriteria_ResourceTag != null)
            {
                context.FilterCriteria_ResourceTag = new List<Amazon.Inspector2.Model.MapFilter>(this.FilterCriteria_ResourceTag);
            }
            if (this.FilterCriteria_ResourceType != null)
            {
                context.FilterCriteria_ResourceType = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_ResourceType);
            }
            if (this.FilterCriteria_Severity != null)
            {
                context.FilterCriteria_Severity = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Severity);
            }
            if (this.FilterCriteria_Title != null)
            {
                context.FilterCriteria_Title = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_Title);
            }
            if (this.FilterCriteria_UpdatedAt != null)
            {
                context.FilterCriteria_UpdatedAt = new List<Amazon.Inspector2.Model.DateFilter>(this.FilterCriteria_UpdatedAt);
            }
            if (this.FilterCriteria_VendorSeverity != null)
            {
                context.FilterCriteria_VendorSeverity = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VendorSeverity);
            }
            if (this.FilterCriteria_VulnerabilityId != null)
            {
                context.FilterCriteria_VulnerabilityId = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VulnerabilityId);
            }
            if (this.FilterCriteria_VulnerabilitySource != null)
            {
                context.FilterCriteria_VulnerabilitySource = new List<Amazon.Inspector2.Model.StringFilter>(this.FilterCriteria_VulnerabilitySource);
            }
            if (this.FilterCriteria_VulnerablePackage != null)
            {
                context.FilterCriteria_VulnerablePackage = new List<Amazon.Inspector2.Model.PackageFilter>(this.FilterCriteria_VulnerablePackage);
            }
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SortCriteria_Field = this.SortCriteria_Field;
            context.SortCriteria_SortOrder = this.SortCriteria_SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Inspector2.Model.ListFindingsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.Inspector2.Model.FilterCriteria();
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_AwsAccountId = null;
            if (cmdletContext.FilterCriteria_AwsAccountId != null)
            {
                requestFilterCriteria_filterCriteria_AwsAccountId = cmdletContext.FilterCriteria_AwsAccountId;
            }
            if (requestFilterCriteria_filterCriteria_AwsAccountId != null)
            {
                request.FilterCriteria.AwsAccountId = requestFilterCriteria_filterCriteria_AwsAccountId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeRepositoryProjectName = null;
            if (cmdletContext.FilterCriteria_CodeRepositoryProjectName != null)
            {
                requestFilterCriteria_filterCriteria_CodeRepositoryProjectName = cmdletContext.FilterCriteria_CodeRepositoryProjectName;
            }
            if (requestFilterCriteria_filterCriteria_CodeRepositoryProjectName != null)
            {
                request.FilterCriteria.CodeRepositoryProjectName = requestFilterCriteria_filterCriteria_CodeRepositoryProjectName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeRepositoryProviderType = null;
            if (cmdletContext.FilterCriteria_CodeRepositoryProviderType != null)
            {
                requestFilterCriteria_filterCriteria_CodeRepositoryProviderType = cmdletContext.FilterCriteria_CodeRepositoryProviderType;
            }
            if (requestFilterCriteria_filterCriteria_CodeRepositoryProviderType != null)
            {
                request.FilterCriteria.CodeRepositoryProviderType = requestFilterCriteria_filterCriteria_CodeRepositoryProviderType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityDetectorName != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName = cmdletContext.FilterCriteria_CodeVulnerabilityDetectorName;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName != null)
            {
                request.FilterCriteria.CodeVulnerabilityDetectorName = requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag = cmdletContext.FilterCriteria_CodeVulnerabilityDetectorTag;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag != null)
            {
                request.FilterCriteria.CodeVulnerabilityDetectorTags = requestFilterCriteria_filterCriteria_CodeVulnerabilityDetectorTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath = null;
            if (cmdletContext.FilterCriteria_CodeVulnerabilityFilePath != null)
            {
                requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath = cmdletContext.FilterCriteria_CodeVulnerabilityFilePath;
            }
            if (requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath != null)
            {
                request.FilterCriteria.CodeVulnerabilityFilePath = requestFilterCriteria_filterCriteria_CodeVulnerabilityFilePath;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ComponentId = null;
            if (cmdletContext.FilterCriteria_ComponentId != null)
            {
                requestFilterCriteria_filterCriteria_ComponentId = cmdletContext.FilterCriteria_ComponentId;
            }
            if (requestFilterCriteria_filterCriteria_ComponentId != null)
            {
                request.FilterCriteria.ComponentId = requestFilterCriteria_filterCriteria_ComponentId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ComponentType = null;
            if (cmdletContext.FilterCriteria_ComponentType != null)
            {
                requestFilterCriteria_filterCriteria_ComponentType = cmdletContext.FilterCriteria_ComponentType;
            }
            if (requestFilterCriteria_filterCriteria_ComponentType != null)
            {
                request.FilterCriteria.ComponentType = requestFilterCriteria_filterCriteria_ComponentType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceImageId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceImageId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceImageId = cmdletContext.FilterCriteria_Ec2InstanceImageId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceImageId != null)
            {
                request.FilterCriteria.Ec2InstanceImageId = requestFilterCriteria_filterCriteria_Ec2InstanceImageId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceSubnetId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId = cmdletContext.FilterCriteria_Ec2InstanceSubnetId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId != null)
            {
                request.FilterCriteria.Ec2InstanceSubnetId = requestFilterCriteria_filterCriteria_Ec2InstanceSubnetId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Ec2InstanceVpcId = null;
            if (cmdletContext.FilterCriteria_Ec2InstanceVpcId != null)
            {
                requestFilterCriteria_filterCriteria_Ec2InstanceVpcId = cmdletContext.FilterCriteria_Ec2InstanceVpcId;
            }
            if (requestFilterCriteria_filterCriteria_Ec2InstanceVpcId != null)
            {
                request.FilterCriteria.Ec2InstanceVpcId = requestFilterCriteria_filterCriteria_Ec2InstanceVpcId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageArchitecture = null;
            if (cmdletContext.FilterCriteria_EcrImageArchitecture != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageArchitecture = cmdletContext.FilterCriteria_EcrImageArchitecture;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageArchitecture != null)
            {
                request.FilterCriteria.EcrImageArchitecture = requestFilterCriteria_filterCriteria_EcrImageArchitecture;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageHash = null;
            if (cmdletContext.FilterCriteria_EcrImageHash != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageHash = cmdletContext.FilterCriteria_EcrImageHash;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageHash != null)
            {
                request.FilterCriteria.EcrImageHash = requestFilterCriteria_filterCriteria_EcrImageHash;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.NumberFilter> requestFilterCriteria_filterCriteria_EcrImageInUseCount = null;
            if (cmdletContext.FilterCriteria_EcrImageInUseCount != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageInUseCount = cmdletContext.FilterCriteria_EcrImageInUseCount;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageInUseCount != null)
            {
                request.FilterCriteria.EcrImageInUseCount = requestFilterCriteria_filterCriteria_EcrImageInUseCount;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_EcrImageLastInUseAt = null;
            if (cmdletContext.FilterCriteria_EcrImageLastInUseAt != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageLastInUseAt = cmdletContext.FilterCriteria_EcrImageLastInUseAt;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageLastInUseAt != null)
            {
                request.FilterCriteria.EcrImageLastInUseAt = requestFilterCriteria_filterCriteria_EcrImageLastInUseAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_EcrImagePushedAt = null;
            if (cmdletContext.FilterCriteria_EcrImagePushedAt != null)
            {
                requestFilterCriteria_filterCriteria_EcrImagePushedAt = cmdletContext.FilterCriteria_EcrImagePushedAt;
            }
            if (requestFilterCriteria_filterCriteria_EcrImagePushedAt != null)
            {
                request.FilterCriteria.EcrImagePushedAt = requestFilterCriteria_filterCriteria_EcrImagePushedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageRegistry = null;
            if (cmdletContext.FilterCriteria_EcrImageRegistry != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageRegistry = cmdletContext.FilterCriteria_EcrImageRegistry;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageRegistry != null)
            {
                request.FilterCriteria.EcrImageRegistry = requestFilterCriteria_filterCriteria_EcrImageRegistry;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageRepositoryName = null;
            if (cmdletContext.FilterCriteria_EcrImageRepositoryName != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageRepositoryName = cmdletContext.FilterCriteria_EcrImageRepositoryName;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageRepositoryName != null)
            {
                request.FilterCriteria.EcrImageRepositoryName = requestFilterCriteria_filterCriteria_EcrImageRepositoryName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_EcrImageTag = null;
            if (cmdletContext.FilterCriteria_EcrImageTag != null)
            {
                requestFilterCriteria_filterCriteria_EcrImageTag = cmdletContext.FilterCriteria_EcrImageTag;
            }
            if (requestFilterCriteria_filterCriteria_EcrImageTag != null)
            {
                request.FilterCriteria.EcrImageTags = requestFilterCriteria_filterCriteria_EcrImageTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.NumberFilter> requestFilterCriteria_filterCriteria_EpssScore = null;
            if (cmdletContext.FilterCriteria_EpssScore != null)
            {
                requestFilterCriteria_filterCriteria_EpssScore = cmdletContext.FilterCriteria_EpssScore;
            }
            if (requestFilterCriteria_filterCriteria_EpssScore != null)
            {
                request.FilterCriteria.EpssScore = requestFilterCriteria_filterCriteria_EpssScore;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ExploitAvailable = null;
            if (cmdletContext.FilterCriteria_ExploitAvailable != null)
            {
                requestFilterCriteria_filterCriteria_ExploitAvailable = cmdletContext.FilterCriteria_ExploitAvailable;
            }
            if (requestFilterCriteria_filterCriteria_ExploitAvailable != null)
            {
                request.FilterCriteria.ExploitAvailable = requestFilterCriteria_filterCriteria_ExploitAvailable;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingArn = null;
            if (cmdletContext.FilterCriteria_FindingArn != null)
            {
                requestFilterCriteria_filterCriteria_FindingArn = cmdletContext.FilterCriteria_FindingArn;
            }
            if (requestFilterCriteria_filterCriteria_FindingArn != null)
            {
                request.FilterCriteria.FindingArn = requestFilterCriteria_filterCriteria_FindingArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingStatus = null;
            if (cmdletContext.FilterCriteria_FindingStatus != null)
            {
                requestFilterCriteria_filterCriteria_FindingStatus = cmdletContext.FilterCriteria_FindingStatus;
            }
            if (requestFilterCriteria_filterCriteria_FindingStatus != null)
            {
                request.FilterCriteria.FindingStatus = requestFilterCriteria_filterCriteria_FindingStatus;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FindingType = null;
            if (cmdletContext.FilterCriteria_FindingType != null)
            {
                requestFilterCriteria_filterCriteria_FindingType = cmdletContext.FilterCriteria_FindingType;
            }
            if (requestFilterCriteria_filterCriteria_FindingType != null)
            {
                request.FilterCriteria.FindingType = requestFilterCriteria_filterCriteria_FindingType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_FirstObservedAt = null;
            if (cmdletContext.FilterCriteria_FirstObservedAt != null)
            {
                requestFilterCriteria_filterCriteria_FirstObservedAt = cmdletContext.FilterCriteria_FirstObservedAt;
            }
            if (requestFilterCriteria_filterCriteria_FirstObservedAt != null)
            {
                request.FilterCriteria.FirstObservedAt = requestFilterCriteria_filterCriteria_FirstObservedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_FixAvailable = null;
            if (cmdletContext.FilterCriteria_FixAvailable != null)
            {
                requestFilterCriteria_filterCriteria_FixAvailable = cmdletContext.FilterCriteria_FixAvailable;
            }
            if (requestFilterCriteria_filterCriteria_FixAvailable != null)
            {
                request.FilterCriteria.FixAvailable = requestFilterCriteria_filterCriteria_FixAvailable;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.NumberFilter> requestFilterCriteria_filterCriteria_InspectorScore = null;
            if (cmdletContext.FilterCriteria_InspectorScore != null)
            {
                requestFilterCriteria_filterCriteria_InspectorScore = cmdletContext.FilterCriteria_InspectorScore;
            }
            if (requestFilterCriteria_filterCriteria_InspectorScore != null)
            {
                request.FilterCriteria.InspectorScore = requestFilterCriteria_filterCriteria_InspectorScore;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn = cmdletContext.FilterCriteria_LambdaFunctionExecutionRoleArn;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn != null)
            {
                request.FilterCriteria.LambdaFunctionExecutionRoleArn = requestFilterCriteria_filterCriteria_LambdaFunctionExecutionRoleArn;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt = cmdletContext.FilterCriteria_LambdaFunctionLastModifiedAt;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt != null)
            {
                request.FilterCriteria.LambdaFunctionLastModifiedAt = requestFilterCriteria_filterCriteria_LambdaFunctionLastModifiedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionLayer = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionLayer != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionLayer = cmdletContext.FilterCriteria_LambdaFunctionLayer;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionLayer != null)
            {
                request.FilterCriteria.LambdaFunctionLayers = requestFilterCriteria_filterCriteria_LambdaFunctionLayer;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionName = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionName != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionName = cmdletContext.FilterCriteria_LambdaFunctionName;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionName != null)
            {
                request.FilterCriteria.LambdaFunctionName = requestFilterCriteria_filterCriteria_LambdaFunctionName;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = null;
            if (cmdletContext.FilterCriteria_LambdaFunctionRuntime != null)
            {
                requestFilterCriteria_filterCriteria_LambdaFunctionRuntime = cmdletContext.FilterCriteria_LambdaFunctionRuntime;
            }
            if (requestFilterCriteria_filterCriteria_LambdaFunctionRuntime != null)
            {
                request.FilterCriteria.LambdaFunctionRuntime = requestFilterCriteria_filterCriteria_LambdaFunctionRuntime;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_LastObservedAt = null;
            if (cmdletContext.FilterCriteria_LastObservedAt != null)
            {
                requestFilterCriteria_filterCriteria_LastObservedAt = cmdletContext.FilterCriteria_LastObservedAt;
            }
            if (requestFilterCriteria_filterCriteria_LastObservedAt != null)
            {
                request.FilterCriteria.LastObservedAt = requestFilterCriteria_filterCriteria_LastObservedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_NetworkProtocol = null;
            if (cmdletContext.FilterCriteria_NetworkProtocol != null)
            {
                requestFilterCriteria_filterCriteria_NetworkProtocol = cmdletContext.FilterCriteria_NetworkProtocol;
            }
            if (requestFilterCriteria_filterCriteria_NetworkProtocol != null)
            {
                request.FilterCriteria.NetworkProtocol = requestFilterCriteria_filterCriteria_NetworkProtocol;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.PortRangeFilter> requestFilterCriteria_filterCriteria_PortRange = null;
            if (cmdletContext.FilterCriteria_PortRange != null)
            {
                requestFilterCriteria_filterCriteria_PortRange = cmdletContext.FilterCriteria_PortRange;
            }
            if (requestFilterCriteria_filterCriteria_PortRange != null)
            {
                request.FilterCriteria.PortRange = requestFilterCriteria_filterCriteria_PortRange;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_RelatedVulnerability = null;
            if (cmdletContext.FilterCriteria_RelatedVulnerability != null)
            {
                requestFilterCriteria_filterCriteria_RelatedVulnerability = cmdletContext.FilterCriteria_RelatedVulnerability;
            }
            if (requestFilterCriteria_filterCriteria_RelatedVulnerability != null)
            {
                request.FilterCriteria.RelatedVulnerabilities = requestFilterCriteria_filterCriteria_RelatedVulnerability;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ResourceId = null;
            if (cmdletContext.FilterCriteria_ResourceId != null)
            {
                requestFilterCriteria_filterCriteria_ResourceId = cmdletContext.FilterCriteria_ResourceId;
            }
            if (requestFilterCriteria_filterCriteria_ResourceId != null)
            {
                request.FilterCriteria.ResourceId = requestFilterCriteria_filterCriteria_ResourceId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.MapFilter> requestFilterCriteria_filterCriteria_ResourceTag = null;
            if (cmdletContext.FilterCriteria_ResourceTag != null)
            {
                requestFilterCriteria_filterCriteria_ResourceTag = cmdletContext.FilterCriteria_ResourceTag;
            }
            if (requestFilterCriteria_filterCriteria_ResourceTag != null)
            {
                request.FilterCriteria.ResourceTags = requestFilterCriteria_filterCriteria_ResourceTag;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_ResourceType = null;
            if (cmdletContext.FilterCriteria_ResourceType != null)
            {
                requestFilterCriteria_filterCriteria_ResourceType = cmdletContext.FilterCriteria_ResourceType;
            }
            if (requestFilterCriteria_filterCriteria_ResourceType != null)
            {
                request.FilterCriteria.ResourceType = requestFilterCriteria_filterCriteria_ResourceType;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Severity = null;
            if (cmdletContext.FilterCriteria_Severity != null)
            {
                requestFilterCriteria_filterCriteria_Severity = cmdletContext.FilterCriteria_Severity;
            }
            if (requestFilterCriteria_filterCriteria_Severity != null)
            {
                request.FilterCriteria.Severity = requestFilterCriteria_filterCriteria_Severity;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_Title = null;
            if (cmdletContext.FilterCriteria_Title != null)
            {
                requestFilterCriteria_filterCriteria_Title = cmdletContext.FilterCriteria_Title;
            }
            if (requestFilterCriteria_filterCriteria_Title != null)
            {
                request.FilterCriteria.Title = requestFilterCriteria_filterCriteria_Title;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.DateFilter> requestFilterCriteria_filterCriteria_UpdatedAt = null;
            if (cmdletContext.FilterCriteria_UpdatedAt != null)
            {
                requestFilterCriteria_filterCriteria_UpdatedAt = cmdletContext.FilterCriteria_UpdatedAt;
            }
            if (requestFilterCriteria_filterCriteria_UpdatedAt != null)
            {
                request.FilterCriteria.UpdatedAt = requestFilterCriteria_filterCriteria_UpdatedAt;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VendorSeverity = null;
            if (cmdletContext.FilterCriteria_VendorSeverity != null)
            {
                requestFilterCriteria_filterCriteria_VendorSeverity = cmdletContext.FilterCriteria_VendorSeverity;
            }
            if (requestFilterCriteria_filterCriteria_VendorSeverity != null)
            {
                request.FilterCriteria.VendorSeverity = requestFilterCriteria_filterCriteria_VendorSeverity;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VulnerabilityId = null;
            if (cmdletContext.FilterCriteria_VulnerabilityId != null)
            {
                requestFilterCriteria_filterCriteria_VulnerabilityId = cmdletContext.FilterCriteria_VulnerabilityId;
            }
            if (requestFilterCriteria_filterCriteria_VulnerabilityId != null)
            {
                request.FilterCriteria.VulnerabilityId = requestFilterCriteria_filterCriteria_VulnerabilityId;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestFilterCriteria_filterCriteria_VulnerabilitySource = null;
            if (cmdletContext.FilterCriteria_VulnerabilitySource != null)
            {
                requestFilterCriteria_filterCriteria_VulnerabilitySource = cmdletContext.FilterCriteria_VulnerabilitySource;
            }
            if (requestFilterCriteria_filterCriteria_VulnerabilitySource != null)
            {
                request.FilterCriteria.VulnerabilitySource = requestFilterCriteria_filterCriteria_VulnerabilitySource;
                requestFilterCriteriaIsNull = false;
            }
            List<Amazon.Inspector2.Model.PackageFilter> requestFilterCriteria_filterCriteria_VulnerablePackage = null;
            if (cmdletContext.FilterCriteria_VulnerablePackage != null)
            {
                requestFilterCriteria_filterCriteria_VulnerablePackage = cmdletContext.FilterCriteria_VulnerablePackage;
            }
            if (requestFilterCriteria_filterCriteria_VulnerablePackage != null)
            {
                request.FilterCriteria.VulnerablePackages = requestFilterCriteria_filterCriteria_VulnerablePackage;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate SortCriteria
            var requestSortCriteriaIsNull = true;
            request.SortCriteria = new Amazon.Inspector2.Model.SortCriteria();
            Amazon.Inspector2.SortField requestSortCriteria_sortCriteria_Field = null;
            if (cmdletContext.SortCriteria_Field != null)
            {
                requestSortCriteria_sortCriteria_Field = cmdletContext.SortCriteria_Field;
            }
            if (requestSortCriteria_sortCriteria_Field != null)
            {
                request.SortCriteria.Field = requestSortCriteria_sortCriteria_Field;
                requestSortCriteriaIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestSortCriteria_sortCriteria_SortOrder = null;
            if (cmdletContext.SortCriteria_SortOrder != null)
            {
                requestSortCriteria_sortCriteria_SortOrder = cmdletContext.SortCriteria_SortOrder;
            }
            if (requestSortCriteria_sortCriteria_SortOrder != null)
            {
                request.SortCriteria.SortOrder = requestSortCriteria_sortCriteria_SortOrder;
                requestSortCriteriaIsNull = false;
            }
             // determine if request.SortCriteria should be set to null
            if (requestSortCriteriaIsNull)
            {
                request.SortCriteria = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Inspector2.Model.ListFindingsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListFindingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListFindings");
            try
            {
                return client.ListFindingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_AwsAccountId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeRepositoryProjectName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeRepositoryProviderType { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityDetectorName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityDetectorTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_CodeVulnerabilityFilePath { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ComponentId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ComponentType { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceImageId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceSubnetId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Ec2InstanceVpcId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageArchitecture { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageHash { get; set; }
            public List<Amazon.Inspector2.Model.NumberFilter> FilterCriteria_EcrImageInUseCount { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_EcrImageLastInUseAt { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_EcrImagePushedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageRegistry { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageRepositoryName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_EcrImageTag { get; set; }
            public List<Amazon.Inspector2.Model.NumberFilter> FilterCriteria_EpssScore { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ExploitAvailable { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingArn { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingStatus { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FindingType { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_FirstObservedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_FixAvailable { get; set; }
            public List<Amazon.Inspector2.Model.NumberFilter> FilterCriteria_InspectorScore { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionExecutionRoleArn { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_LambdaFunctionLastModifiedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionLayer { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_LambdaFunctionRuntime { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_LastObservedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_NetworkProtocol { get; set; }
            public List<Amazon.Inspector2.Model.PortRangeFilter> FilterCriteria_PortRange { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_RelatedVulnerability { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.MapFilter> FilterCriteria_ResourceTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_ResourceType { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Severity { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_Title { get; set; }
            public List<Amazon.Inspector2.Model.DateFilter> FilterCriteria_UpdatedAt { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VendorSeverity { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VulnerabilityId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> FilterCriteria_VulnerabilitySource { get; set; }
            public List<Amazon.Inspector2.Model.PackageFilter> FilterCriteria_VulnerablePackage { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Inspector2.SortField SortCriteria_Field { get; set; }
            public Amazon.Inspector2.SortOrder SortCriteria_SortOrder { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListFindingsResponse, GetINS2FindingListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Findings;
        }
        
    }
}
