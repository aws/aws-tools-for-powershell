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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Lists aggregated finding data for your environment based on specific criteria.
    /// </summary>
    [Cmdlet("Get", "INS2FindingAggregationList")]
    [OutputType("Amazon.Inspector2.Model.ListFindingAggregationsResponse")]
    [AWSCmdlet("Calls the Inspector2 ListFindingAggregations API operation.", Operation = new[] {"ListFindingAggregations"}, SelectReturnType = typeof(Amazon.Inspector2.Model.ListFindingAggregationsResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.ListFindingAggregationsResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.ListFindingAggregationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetINS2FindingAggregationListCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs to retrieve finding aggregation data for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public Amazon.Inspector2.Model.StringFilter[] AccountId { get; set; }
        #endregion
        
        #region Parameter AggregationType
        /// <summary>
        /// <para>
        /// <para>The type of the aggregation request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationType")]
        public Amazon.Inspector2.AggregationType AggregationType { get; set; }
        #endregion
        
        #region Parameter AmiAggregation_Ami
        /// <summary>
        /// <para>
        /// <para>The IDs of AMIs to aggregate findings for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AmiAggregation_Amis")]
        public Amazon.Inspector2.Model.StringFilter[] AmiAggregation_Ami { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_Ami
        /// <summary>
        /// <para>
        /// <para>The AMI IDs associated with the Amazon EC2 instances to aggregate findings for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_Amis")]
        public Amazon.Inspector2.Model.StringFilter[] Ec2InstanceAggregation_Ami { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_Architectures")]
        public Amazon.Inspector2.Model.StringFilter[] AwsEcrContainerAggregation_Architecture { get; set; }
        #endregion
        
        #region Parameter AccountAggregation_FindingType
        /// <summary>
        /// <para>
        /// <para>The type of finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AccountAggregation_FindingType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationFindingType")]
        public Amazon.Inspector2.AggregationFindingType AccountAggregation_FindingType { get; set; }
        #endregion
        
        #region Parameter FindingTypeAggregation_FindingType
        /// <summary>
        /// <para>
        /// <para>The finding type to aggregate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_FindingTypeAggregation_FindingType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationFindingType")]
        public Amazon.Inspector2.AggregationFindingType FindingTypeAggregation_FindingType { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_FindingType
        /// <summary>
        /// <para>
        /// <para>The type of finding to aggregate on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_FindingType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationFindingType")]
        public Amazon.Inspector2.AggregationFindingType TitleAggregation_FindingType { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_FunctionName
        /// <summary>
        /// <para>
        /// <para>The AWS Lambda function names to include in the aggregation results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_FunctionNames")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaFunctionAggregation_FunctionName { get; set; }
        #endregion
        
        #region Parameter LambdaLayerAggregation_FunctionName
        /// <summary>
        /// <para>
        /// <para>The names of the AWS Lambda functions associated with the layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaLayerAggregation_FunctionNames")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaLayerAggregation_FunctionName { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_FunctionTag
        /// <summary>
        /// <para>
        /// <para>The tags to include in the aggregation results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_FunctionTags")]
        public Amazon.Inspector2.Model.MapFilter[] LambdaFunctionAggregation_FunctionTag { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_ImageSha
        /// <summary>
        /// <para>
        /// <para>The image SHA values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_ImageShas")]
        public Amazon.Inspector2.Model.StringFilter[] AwsEcrContainerAggregation_ImageSha { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_ImageTag
        /// <summary>
        /// <para>
        /// <para>The image tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_ImageTags")]
        public Amazon.Inspector2.Model.StringFilter[] AwsEcrContainerAggregation_ImageTag { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_InstanceId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance IDs to aggregate findings for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_InstanceIds")]
        public Amazon.Inspector2.Model.StringFilter[] Ec2InstanceAggregation_InstanceId { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_InstanceTag
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 instance tags to aggregate findings for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_InstanceTags")]
        public Amazon.Inspector2.Model.MapFilter[] Ec2InstanceAggregation_InstanceTag { get; set; }
        #endregion
        
        #region Parameter LambdaLayerAggregation_LayerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Lambda function layer. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaLayerAggregation_LayerArns")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaLayerAggregation_LayerArn { get; set; }
        #endregion
        
        #region Parameter ImageLayerAggregation_LayerHash
        /// <summary>
        /// <para>
        /// <para>The hashes associated with the layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_ImageLayerAggregation_LayerHashes")]
        public Amazon.Inspector2.Model.StringFilter[] ImageLayerAggregation_LayerHash { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_OperatingSystem
        /// <summary>
        /// <para>
        /// <para>The operating system types to aggregate findings for. Valid values must be uppercase
        /// and underscore separated, examples are <code>ORACLE_LINUX_7</code> and <code>ALPINE_LINUX_3_8</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_OperatingSystems")]
        public Amazon.Inspector2.Model.StringFilter[] Ec2InstanceAggregation_OperatingSystem { get; set; }
        #endregion
        
        #region Parameter PackageAggregation_PackageName
        /// <summary>
        /// <para>
        /// <para>The names of packages to aggregate findings on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_PackageAggregation_PackageNames")]
        public Amazon.Inspector2.Model.StringFilter[] PackageAggregation_PackageName { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_Repository
        /// <summary>
        /// <para>
        /// <para>The container repositories.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_Repositories")]
        public Amazon.Inspector2.Model.StringFilter[] AwsEcrContainerAggregation_Repository { get; set; }
        #endregion
        
        #region Parameter ImageLayerAggregation_Repository
        /// <summary>
        /// <para>
        /// <para>The repository associated with the container image hosting the layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_ImageLayerAggregation_Repositories")]
        public Amazon.Inspector2.Model.StringFilter[] ImageLayerAggregation_Repository { get; set; }
        #endregion
        
        #region Parameter RepositoryAggregation_Repository
        /// <summary>
        /// <para>
        /// <para>The names of repositories to aggregate findings on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_RepositoryAggregation_Repositories")]
        public Amazon.Inspector2.Model.StringFilter[] RepositoryAggregation_Repository { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_ResourceId
        /// <summary>
        /// <para>
        /// <para>The container resource IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_ResourceIds")]
        public Amazon.Inspector2.Model.StringFilter[] AwsEcrContainerAggregation_ResourceId { get; set; }
        #endregion
        
        #region Parameter ImageLayerAggregation_ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the container image layer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_ImageLayerAggregation_ResourceIds")]
        public Amazon.Inspector2.Model.StringFilter[] ImageLayerAggregation_ResourceId { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource IDs to include in the aggregation results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_ResourceIds")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaFunctionAggregation_ResourceId { get; set; }
        #endregion
        
        #region Parameter LambdaLayerAggregation_ResourceId
        /// <summary>
        /// <para>
        /// <para>The resource IDs for the AWS Lambda function layers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaLayerAggregation_ResourceIds")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaLayerAggregation_ResourceId { get; set; }
        #endregion
        
        #region Parameter AccountAggregation_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AccountAggregation_ResourceType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationResourceType")]
        public Amazon.Inspector2.AggregationResourceType AccountAggregation_ResourceType { get; set; }
        #endregion
        
        #region Parameter FindingTypeAggregation_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type to aggregate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_FindingTypeAggregation_ResourceType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationResourceType")]
        public Amazon.Inspector2.AggregationResourceType FindingTypeAggregation_ResourceType { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_ResourceType
        /// <summary>
        /// <para>
        /// <para>The resource type to aggregate on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_ResourceType")]
        [AWSConstantClassSource("Amazon.Inspector2.AggregationResourceType")]
        public Amazon.Inspector2.AggregationResourceType TitleAggregation_ResourceType { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_Runtime
        /// <summary>
        /// <para>
        /// <para>Returns findings aggregated by AWS Lambda function runtime environments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_Runtimes")]
        public Amazon.Inspector2.Model.StringFilter[] LambdaFunctionAggregation_Runtime { get; set; }
        #endregion
        
        #region Parameter AccountAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AccountAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.AccountSortBy")]
        public Amazon.Inspector2.AccountSortBy AccountAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter AmiAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AmiAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.AmiSortBy")]
        public Amazon.Inspector2.AmiSortBy AmiAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.AwsEcrContainerSortBy")]
        public Amazon.Inspector2.AwsEcrContainerSortBy AwsEcrContainerAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.Ec2InstanceSortBy")]
        public Amazon.Inspector2.Ec2InstanceSortBy Ec2InstanceAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter FindingTypeAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_FindingTypeAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.FindingTypeSortBy")]
        public Amazon.Inspector2.FindingTypeSortBy FindingTypeAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter ImageLayerAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_ImageLayerAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.ImageLayerSortBy")]
        public Amazon.Inspector2.ImageLayerSortBy ImageLayerAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The finding severity to use for sorting the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.LambdaFunctionSortBy")]
        public Amazon.Inspector2.LambdaFunctionSortBy LambdaFunctionAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter LambdaLayerAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The finding severity to use for sorting the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaLayerAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.LambdaLayerSortBy")]
        public Amazon.Inspector2.LambdaLayerSortBy LambdaLayerAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter PackageAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_PackageAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.PackageSortBy")]
        public Amazon.Inspector2.PackageSortBy PackageAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter RepositoryAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_RepositoryAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.RepositorySortBy")]
        public Amazon.Inspector2.RepositorySortBy RepositoryAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_SortBy
        /// <summary>
        /// <para>
        /// <para>The value to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_SortBy")]
        [AWSConstantClassSource("Amazon.Inspector2.TitleSortBy")]
        public Amazon.Inspector2.TitleSortBy TitleAggregation_SortBy { get; set; }
        #endregion
        
        #region Parameter AccountAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AccountAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder AccountAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter AmiAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AmiAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder AmiAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter AwsEcrContainerAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order (ascending or descending).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_AwsEcrContainerAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder AwsEcrContainerAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter Ec2InstanceAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_Ec2InstanceAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder Ec2InstanceAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter FindingTypeAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_FindingTypeAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder FindingTypeAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter ImageLayerAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_ImageLayerAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder ImageLayerAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to use for sorting the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaFunctionAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder LambdaFunctionAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter LambdaLayerAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to use for sorting the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_LambdaLayerAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder LambdaLayerAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter PackageAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_PackageAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder PackageAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter RepositoryAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_RepositoryAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder RepositoryAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_SortOrder")]
        [AWSConstantClassSource("Amazon.Inspector2.SortOrder")]
        public Amazon.Inspector2.SortOrder TitleAggregation_SortOrder { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_Title
        /// <summary>
        /// <para>
        /// <para>The finding titles to aggregate on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_Titles")]
        public Amazon.Inspector2.Model.StringFilter[] TitleAggregation_Title { get; set; }
        #endregion
        
        #region Parameter TitleAggregation_VulnerabilityId
        /// <summary>
        /// <para>
        /// <para>The vulnerability IDs of the findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AggregationRequest_TitleAggregation_VulnerabilityIds")]
        public Amazon.Inspector2.Model.StringFilter[] TitleAggregation_VulnerabilityId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results the response can return. If your request would return
        /// more than the maximum the response will return a <code>nextToken</code> value, use
        /// this value when you call the action again to get the remaining results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to use for paginating results that are returned in the response. Set the value
        /// of this parameter to null for the first request to a list action. If your response
        /// returns more than the <code>maxResults</code> maximum value it will also return a
        /// <code>nextToken</code> value. For subsequent calls, use the <code>nextToken</code>
        /// value returned from the previous request to continue listing results after the first
        /// page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.ListFindingAggregationsResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.ListFindingAggregationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AggregationType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AggregationType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AggregationType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.ListFindingAggregationsResponse, GetINS2FindingAggregationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AggregationType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AccountId != null)
            {
                context.AccountId = new List<Amazon.Inspector2.Model.StringFilter>(this.AccountId);
            }
            context.AccountAggregation_FindingType = this.AccountAggregation_FindingType;
            context.AccountAggregation_ResourceType = this.AccountAggregation_ResourceType;
            context.AccountAggregation_SortBy = this.AccountAggregation_SortBy;
            context.AccountAggregation_SortOrder = this.AccountAggregation_SortOrder;
            if (this.AmiAggregation_Ami != null)
            {
                context.AmiAggregation_Ami = new List<Amazon.Inspector2.Model.StringFilter>(this.AmiAggregation_Ami);
            }
            context.AmiAggregation_SortBy = this.AmiAggregation_SortBy;
            context.AmiAggregation_SortOrder = this.AmiAggregation_SortOrder;
            if (this.AwsEcrContainerAggregation_Architecture != null)
            {
                context.AwsEcrContainerAggregation_Architecture = new List<Amazon.Inspector2.Model.StringFilter>(this.AwsEcrContainerAggregation_Architecture);
            }
            if (this.AwsEcrContainerAggregation_ImageSha != null)
            {
                context.AwsEcrContainerAggregation_ImageSha = new List<Amazon.Inspector2.Model.StringFilter>(this.AwsEcrContainerAggregation_ImageSha);
            }
            if (this.AwsEcrContainerAggregation_ImageTag != null)
            {
                context.AwsEcrContainerAggregation_ImageTag = new List<Amazon.Inspector2.Model.StringFilter>(this.AwsEcrContainerAggregation_ImageTag);
            }
            if (this.AwsEcrContainerAggregation_Repository != null)
            {
                context.AwsEcrContainerAggregation_Repository = new List<Amazon.Inspector2.Model.StringFilter>(this.AwsEcrContainerAggregation_Repository);
            }
            if (this.AwsEcrContainerAggregation_ResourceId != null)
            {
                context.AwsEcrContainerAggregation_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.AwsEcrContainerAggregation_ResourceId);
            }
            context.AwsEcrContainerAggregation_SortBy = this.AwsEcrContainerAggregation_SortBy;
            context.AwsEcrContainerAggregation_SortOrder = this.AwsEcrContainerAggregation_SortOrder;
            if (this.Ec2InstanceAggregation_Ami != null)
            {
                context.Ec2InstanceAggregation_Ami = new List<Amazon.Inspector2.Model.StringFilter>(this.Ec2InstanceAggregation_Ami);
            }
            if (this.Ec2InstanceAggregation_InstanceId != null)
            {
                context.Ec2InstanceAggregation_InstanceId = new List<Amazon.Inspector2.Model.StringFilter>(this.Ec2InstanceAggregation_InstanceId);
            }
            if (this.Ec2InstanceAggregation_InstanceTag != null)
            {
                context.Ec2InstanceAggregation_InstanceTag = new List<Amazon.Inspector2.Model.MapFilter>(this.Ec2InstanceAggregation_InstanceTag);
            }
            if (this.Ec2InstanceAggregation_OperatingSystem != null)
            {
                context.Ec2InstanceAggregation_OperatingSystem = new List<Amazon.Inspector2.Model.StringFilter>(this.Ec2InstanceAggregation_OperatingSystem);
            }
            context.Ec2InstanceAggregation_SortBy = this.Ec2InstanceAggregation_SortBy;
            context.Ec2InstanceAggregation_SortOrder = this.Ec2InstanceAggregation_SortOrder;
            context.FindingTypeAggregation_FindingType = this.FindingTypeAggregation_FindingType;
            context.FindingTypeAggregation_ResourceType = this.FindingTypeAggregation_ResourceType;
            context.FindingTypeAggregation_SortBy = this.FindingTypeAggregation_SortBy;
            context.FindingTypeAggregation_SortOrder = this.FindingTypeAggregation_SortOrder;
            if (this.ImageLayerAggregation_LayerHash != null)
            {
                context.ImageLayerAggregation_LayerHash = new List<Amazon.Inspector2.Model.StringFilter>(this.ImageLayerAggregation_LayerHash);
            }
            if (this.ImageLayerAggregation_Repository != null)
            {
                context.ImageLayerAggregation_Repository = new List<Amazon.Inspector2.Model.StringFilter>(this.ImageLayerAggregation_Repository);
            }
            if (this.ImageLayerAggregation_ResourceId != null)
            {
                context.ImageLayerAggregation_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.ImageLayerAggregation_ResourceId);
            }
            context.ImageLayerAggregation_SortBy = this.ImageLayerAggregation_SortBy;
            context.ImageLayerAggregation_SortOrder = this.ImageLayerAggregation_SortOrder;
            if (this.LambdaFunctionAggregation_FunctionName != null)
            {
                context.LambdaFunctionAggregation_FunctionName = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaFunctionAggregation_FunctionName);
            }
            if (this.LambdaFunctionAggregation_FunctionTag != null)
            {
                context.LambdaFunctionAggregation_FunctionTag = new List<Amazon.Inspector2.Model.MapFilter>(this.LambdaFunctionAggregation_FunctionTag);
            }
            if (this.LambdaFunctionAggregation_ResourceId != null)
            {
                context.LambdaFunctionAggregation_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaFunctionAggregation_ResourceId);
            }
            if (this.LambdaFunctionAggregation_Runtime != null)
            {
                context.LambdaFunctionAggregation_Runtime = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaFunctionAggregation_Runtime);
            }
            context.LambdaFunctionAggregation_SortBy = this.LambdaFunctionAggregation_SortBy;
            context.LambdaFunctionAggregation_SortOrder = this.LambdaFunctionAggregation_SortOrder;
            if (this.LambdaLayerAggregation_FunctionName != null)
            {
                context.LambdaLayerAggregation_FunctionName = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaLayerAggregation_FunctionName);
            }
            if (this.LambdaLayerAggregation_LayerArn != null)
            {
                context.LambdaLayerAggregation_LayerArn = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaLayerAggregation_LayerArn);
            }
            if (this.LambdaLayerAggregation_ResourceId != null)
            {
                context.LambdaLayerAggregation_ResourceId = new List<Amazon.Inspector2.Model.StringFilter>(this.LambdaLayerAggregation_ResourceId);
            }
            context.LambdaLayerAggregation_SortBy = this.LambdaLayerAggregation_SortBy;
            context.LambdaLayerAggregation_SortOrder = this.LambdaLayerAggregation_SortOrder;
            if (this.PackageAggregation_PackageName != null)
            {
                context.PackageAggregation_PackageName = new List<Amazon.Inspector2.Model.StringFilter>(this.PackageAggregation_PackageName);
            }
            context.PackageAggregation_SortBy = this.PackageAggregation_SortBy;
            context.PackageAggregation_SortOrder = this.PackageAggregation_SortOrder;
            if (this.RepositoryAggregation_Repository != null)
            {
                context.RepositoryAggregation_Repository = new List<Amazon.Inspector2.Model.StringFilter>(this.RepositoryAggregation_Repository);
            }
            context.RepositoryAggregation_SortBy = this.RepositoryAggregation_SortBy;
            context.RepositoryAggregation_SortOrder = this.RepositoryAggregation_SortOrder;
            context.TitleAggregation_FindingType = this.TitleAggregation_FindingType;
            context.TitleAggregation_ResourceType = this.TitleAggregation_ResourceType;
            context.TitleAggregation_SortBy = this.TitleAggregation_SortBy;
            context.TitleAggregation_SortOrder = this.TitleAggregation_SortOrder;
            if (this.TitleAggregation_Title != null)
            {
                context.TitleAggregation_Title = new List<Amazon.Inspector2.Model.StringFilter>(this.TitleAggregation_Title);
            }
            if (this.TitleAggregation_VulnerabilityId != null)
            {
                context.TitleAggregation_VulnerabilityId = new List<Amazon.Inspector2.Model.StringFilter>(this.TitleAggregation_VulnerabilityId);
            }
            context.AggregationType = this.AggregationType;
            #if MODULAR
            if (this.AggregationType == null && ParameterWasBound(nameof(this.AggregationType)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Inspector2.Model.ListFindingAggregationsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            
             // populate AggregationRequest
            var requestAggregationRequestIsNull = true;
            request.AggregationRequest = new Amazon.Inspector2.Model.AggregationRequest();
            Amazon.Inspector2.Model.AmiAggregation requestAggregationRequest_aggregationRequest_AmiAggregation = null;
            
             // populate AmiAggregation
            var requestAggregationRequest_aggregationRequest_AmiAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_AmiAggregation = new Amazon.Inspector2.Model.AmiAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_Ami = null;
            if (cmdletContext.AmiAggregation_Ami != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_Ami = cmdletContext.AmiAggregation_Ami;
            }
            if (requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_Ami != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation.Amis = requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_Ami;
                requestAggregationRequest_aggregationRequest_AmiAggregationIsNull = false;
            }
            Amazon.Inspector2.AmiSortBy requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortBy = null;
            if (cmdletContext.AmiAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortBy = cmdletContext.AmiAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation.SortBy = requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_AmiAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortOrder = null;
            if (cmdletContext.AmiAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortOrder = cmdletContext.AmiAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation.SortOrder = requestAggregationRequest_aggregationRequest_AmiAggregation_amiAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_AmiAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_AmiAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_AmiAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_AmiAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_AmiAggregation != null)
            {
                request.AggregationRequest.AmiAggregation = requestAggregationRequest_aggregationRequest_AmiAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.PackageAggregation requestAggregationRequest_aggregationRequest_PackageAggregation = null;
            
             // populate PackageAggregation
            var requestAggregationRequest_aggregationRequest_PackageAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_PackageAggregation = new Amazon.Inspector2.Model.PackageAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_PackageName = null;
            if (cmdletContext.PackageAggregation_PackageName != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_PackageName = cmdletContext.PackageAggregation_PackageName;
            }
            if (requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_PackageName != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation.PackageNames = requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_PackageName;
                requestAggregationRequest_aggregationRequest_PackageAggregationIsNull = false;
            }
            Amazon.Inspector2.PackageSortBy requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortBy = null;
            if (cmdletContext.PackageAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortBy = cmdletContext.PackageAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation.SortBy = requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_PackageAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortOrder = null;
            if (cmdletContext.PackageAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortOrder = cmdletContext.PackageAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation.SortOrder = requestAggregationRequest_aggregationRequest_PackageAggregation_packageAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_PackageAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_PackageAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_PackageAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_PackageAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_PackageAggregation != null)
            {
                request.AggregationRequest.PackageAggregation = requestAggregationRequest_aggregationRequest_PackageAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.RepositoryAggregation requestAggregationRequest_aggregationRequest_RepositoryAggregation = null;
            
             // populate RepositoryAggregation
            var requestAggregationRequest_aggregationRequest_RepositoryAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_RepositoryAggregation = new Amazon.Inspector2.Model.RepositoryAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_Repository = null;
            if (cmdletContext.RepositoryAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_Repository = cmdletContext.RepositoryAggregation_Repository;
            }
            if (requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation.Repositories = requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_Repository;
                requestAggregationRequest_aggregationRequest_RepositoryAggregationIsNull = false;
            }
            Amazon.Inspector2.RepositorySortBy requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortBy = null;
            if (cmdletContext.RepositoryAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortBy = cmdletContext.RepositoryAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation.SortBy = requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_RepositoryAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortOrder = null;
            if (cmdletContext.RepositoryAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortOrder = cmdletContext.RepositoryAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation.SortOrder = requestAggregationRequest_aggregationRequest_RepositoryAggregation_repositoryAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_RepositoryAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_RepositoryAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_RepositoryAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_RepositoryAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_RepositoryAggregation != null)
            {
                request.AggregationRequest.RepositoryAggregation = requestAggregationRequest_aggregationRequest_RepositoryAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.AccountAggregation requestAggregationRequest_aggregationRequest_AccountAggregation = null;
            
             // populate AccountAggregation
            var requestAggregationRequest_aggregationRequest_AccountAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_AccountAggregation = new Amazon.Inspector2.Model.AccountAggregation();
            Amazon.Inspector2.AggregationFindingType requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_FindingType = null;
            if (cmdletContext.AccountAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_FindingType = cmdletContext.AccountAggregation_FindingType;
            }
            if (requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation.FindingType = requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_FindingType;
                requestAggregationRequest_aggregationRequest_AccountAggregationIsNull = false;
            }
            Amazon.Inspector2.AggregationResourceType requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_ResourceType = null;
            if (cmdletContext.AccountAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_ResourceType = cmdletContext.AccountAggregation_ResourceType;
            }
            if (requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation.ResourceType = requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_ResourceType;
                requestAggregationRequest_aggregationRequest_AccountAggregationIsNull = false;
            }
            Amazon.Inspector2.AccountSortBy requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortBy = null;
            if (cmdletContext.AccountAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortBy = cmdletContext.AccountAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation.SortBy = requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_AccountAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortOrder = null;
            if (cmdletContext.AccountAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortOrder = cmdletContext.AccountAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation.SortOrder = requestAggregationRequest_aggregationRequest_AccountAggregation_accountAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_AccountAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_AccountAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_AccountAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_AccountAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_AccountAggregation != null)
            {
                request.AggregationRequest.AccountAggregation = requestAggregationRequest_aggregationRequest_AccountAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.FindingTypeAggregation requestAggregationRequest_aggregationRequest_FindingTypeAggregation = null;
            
             // populate FindingTypeAggregation
            var requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_FindingTypeAggregation = new Amazon.Inspector2.Model.FindingTypeAggregation();
            Amazon.Inspector2.AggregationFindingType requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_FindingType = null;
            if (cmdletContext.FindingTypeAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_FindingType = cmdletContext.FindingTypeAggregation_FindingType;
            }
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation.FindingType = requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_FindingType;
                requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull = false;
            }
            Amazon.Inspector2.AggregationResourceType requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_ResourceType = null;
            if (cmdletContext.FindingTypeAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_ResourceType = cmdletContext.FindingTypeAggregation_ResourceType;
            }
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation.ResourceType = requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_ResourceType;
                requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull = false;
            }
            Amazon.Inspector2.FindingTypeSortBy requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortBy = null;
            if (cmdletContext.FindingTypeAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortBy = cmdletContext.FindingTypeAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation.SortBy = requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortOrder = null;
            if (cmdletContext.FindingTypeAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortOrder = cmdletContext.FindingTypeAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation.SortOrder = requestAggregationRequest_aggregationRequest_FindingTypeAggregation_findingTypeAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_FindingTypeAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_FindingTypeAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_FindingTypeAggregation != null)
            {
                request.AggregationRequest.FindingTypeAggregation = requestAggregationRequest_aggregationRequest_FindingTypeAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.ImageLayerAggregation requestAggregationRequest_aggregationRequest_ImageLayerAggregation = null;
            
             // populate ImageLayerAggregation
            var requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_ImageLayerAggregation = new Amazon.Inspector2.Model.ImageLayerAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_LayerHash = null;
            if (cmdletContext.ImageLayerAggregation_LayerHash != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_LayerHash = cmdletContext.ImageLayerAggregation_LayerHash;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_LayerHash != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation.LayerHashes = requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_LayerHash;
                requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_Repository = null;
            if (cmdletContext.ImageLayerAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_Repository = cmdletContext.ImageLayerAggregation_Repository;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation.Repositories = requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_Repository;
                requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_ResourceId = null;
            if (cmdletContext.ImageLayerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_ResourceId = cmdletContext.ImageLayerAggregation_ResourceId;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation.ResourceIds = requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_ResourceId;
                requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = false;
            }
            Amazon.Inspector2.ImageLayerSortBy requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortBy = null;
            if (cmdletContext.ImageLayerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortBy = cmdletContext.ImageLayerAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation.SortBy = requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortOrder = null;
            if (cmdletContext.ImageLayerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortOrder = cmdletContext.ImageLayerAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation.SortOrder = requestAggregationRequest_aggregationRequest_ImageLayerAggregation_imageLayerAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_ImageLayerAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_ImageLayerAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_ImageLayerAggregation != null)
            {
                request.AggregationRequest.ImageLayerAggregation = requestAggregationRequest_aggregationRequest_ImageLayerAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.LambdaLayerAggregation requestAggregationRequest_aggregationRequest_LambdaLayerAggregation = null;
            
             // populate LambdaLayerAggregation
            var requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_LambdaLayerAggregation = new Amazon.Inspector2.Model.LambdaLayerAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_FunctionName = null;
            if (cmdletContext.LambdaLayerAggregation_FunctionName != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_FunctionName = cmdletContext.LambdaLayerAggregation_FunctionName;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_FunctionName != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation.FunctionNames = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_FunctionName;
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_LayerArn = null;
            if (cmdletContext.LambdaLayerAggregation_LayerArn != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_LayerArn = cmdletContext.LambdaLayerAggregation_LayerArn;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_LayerArn != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation.LayerArns = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_LayerArn;
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_ResourceId = null;
            if (cmdletContext.LambdaLayerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_ResourceId = cmdletContext.LambdaLayerAggregation_ResourceId;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation.ResourceIds = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_ResourceId;
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = false;
            }
            Amazon.Inspector2.LambdaLayerSortBy requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortBy = null;
            if (cmdletContext.LambdaLayerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortBy = cmdletContext.LambdaLayerAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation.SortBy = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortOrder = null;
            if (cmdletContext.LambdaLayerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortOrder = cmdletContext.LambdaLayerAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation.SortOrder = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation_lambdaLayerAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_LambdaLayerAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_LambdaLayerAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaLayerAggregation != null)
            {
                request.AggregationRequest.LambdaLayerAggregation = requestAggregationRequest_aggregationRequest_LambdaLayerAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.Ec2InstanceAggregation requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation = null;
            
             // populate Ec2InstanceAggregation
            var requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation = new Amazon.Inspector2.Model.Ec2InstanceAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_Ami = null;
            if (cmdletContext.Ec2InstanceAggregation_Ami != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_Ami = cmdletContext.Ec2InstanceAggregation_Ami;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_Ami != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.Amis = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_Ami;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceId = null;
            if (cmdletContext.Ec2InstanceAggregation_InstanceId != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceId = cmdletContext.Ec2InstanceAggregation_InstanceId;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceId != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.InstanceIds = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceId;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.MapFilter> requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceTag = null;
            if (cmdletContext.Ec2InstanceAggregation_InstanceTag != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceTag = cmdletContext.Ec2InstanceAggregation_InstanceTag;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceTag != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.InstanceTags = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_InstanceTag;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_OperatingSystem = null;
            if (cmdletContext.Ec2InstanceAggregation_OperatingSystem != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_OperatingSystem = cmdletContext.Ec2InstanceAggregation_OperatingSystem;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_OperatingSystem != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.OperatingSystems = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_OperatingSystem;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
            Amazon.Inspector2.Ec2InstanceSortBy requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortBy = null;
            if (cmdletContext.Ec2InstanceAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortBy = cmdletContext.Ec2InstanceAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.SortBy = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortOrder = null;
            if (cmdletContext.Ec2InstanceAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortOrder = cmdletContext.Ec2InstanceAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation.SortOrder = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation_ec2InstanceAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation != null)
            {
                request.AggregationRequest.Ec2InstanceAggregation = requestAggregationRequest_aggregationRequest_Ec2InstanceAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.LambdaFunctionAggregation requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation = null;
            
             // populate LambdaFunctionAggregation
            var requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation = new Amazon.Inspector2.Model.LambdaFunctionAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionName = null;
            if (cmdletContext.LambdaFunctionAggregation_FunctionName != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionName = cmdletContext.LambdaFunctionAggregation_FunctionName;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionName != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.FunctionNames = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionName;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.MapFilter> requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionTag = null;
            if (cmdletContext.LambdaFunctionAggregation_FunctionTag != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionTag = cmdletContext.LambdaFunctionAggregation_FunctionTag;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionTag != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.FunctionTags = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_FunctionTag;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_ResourceId = null;
            if (cmdletContext.LambdaFunctionAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_ResourceId = cmdletContext.LambdaFunctionAggregation_ResourceId;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.ResourceIds = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_ResourceId;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_Runtime = null;
            if (cmdletContext.LambdaFunctionAggregation_Runtime != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_Runtime = cmdletContext.LambdaFunctionAggregation_Runtime;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_Runtime != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.Runtimes = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_Runtime;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
            Amazon.Inspector2.LambdaFunctionSortBy requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortBy = null;
            if (cmdletContext.LambdaFunctionAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortBy = cmdletContext.LambdaFunctionAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.SortBy = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortOrder = null;
            if (cmdletContext.LambdaFunctionAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortOrder = cmdletContext.LambdaFunctionAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation.SortOrder = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation_lambdaFunctionAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation != null)
            {
                request.AggregationRequest.LambdaFunctionAggregation = requestAggregationRequest_aggregationRequest_LambdaFunctionAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.TitleAggregation requestAggregationRequest_aggregationRequest_TitleAggregation = null;
            
             // populate TitleAggregation
            var requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_TitleAggregation = new Amazon.Inspector2.Model.TitleAggregation();
            Amazon.Inspector2.AggregationFindingType requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_FindingType = null;
            if (cmdletContext.TitleAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_FindingType = cmdletContext.TitleAggregation_FindingType;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_FindingType != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.FindingType = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_FindingType;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
            Amazon.Inspector2.AggregationResourceType requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_ResourceType = null;
            if (cmdletContext.TitleAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_ResourceType = cmdletContext.TitleAggregation_ResourceType;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_ResourceType != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.ResourceType = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_ResourceType;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
            Amazon.Inspector2.TitleSortBy requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortBy = null;
            if (cmdletContext.TitleAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortBy = cmdletContext.TitleAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.SortBy = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortOrder = null;
            if (cmdletContext.TitleAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortOrder = cmdletContext.TitleAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.SortOrder = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_Title = null;
            if (cmdletContext.TitleAggregation_Title != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_Title = cmdletContext.TitleAggregation_Title;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_Title != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.Titles = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_Title;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_VulnerabilityId = null;
            if (cmdletContext.TitleAggregation_VulnerabilityId != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_VulnerabilityId = cmdletContext.TitleAggregation_VulnerabilityId;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_VulnerabilityId != null)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation.VulnerabilityIds = requestAggregationRequest_aggregationRequest_TitleAggregation_titleAggregation_VulnerabilityId;
                requestAggregationRequest_aggregationRequest_TitleAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_TitleAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_TitleAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_TitleAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_TitleAggregation != null)
            {
                request.AggregationRequest.TitleAggregation = requestAggregationRequest_aggregationRequest_TitleAggregation;
                requestAggregationRequestIsNull = false;
            }
            Amazon.Inspector2.Model.AwsEcrContainerAggregation requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation = null;
            
             // populate AwsEcrContainerAggregation
            var requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = true;
            requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation = new Amazon.Inspector2.Model.AwsEcrContainerAggregation();
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Architecture = null;
            if (cmdletContext.AwsEcrContainerAggregation_Architecture != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Architecture = cmdletContext.AwsEcrContainerAggregation_Architecture;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Architecture != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.Architectures = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Architecture;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageSha = null;
            if (cmdletContext.AwsEcrContainerAggregation_ImageSha != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageSha = cmdletContext.AwsEcrContainerAggregation_ImageSha;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageSha != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.ImageShas = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageSha;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageTag = null;
            if (cmdletContext.AwsEcrContainerAggregation_ImageTag != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageTag = cmdletContext.AwsEcrContainerAggregation_ImageTag;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageTag != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.ImageTags = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ImageTag;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Repository = null;
            if (cmdletContext.AwsEcrContainerAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Repository = cmdletContext.AwsEcrContainerAggregation_Repository;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Repository != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.Repositories = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_Repository;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            List<Amazon.Inspector2.Model.StringFilter> requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ResourceId = null;
            if (cmdletContext.AwsEcrContainerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ResourceId = cmdletContext.AwsEcrContainerAggregation_ResourceId;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ResourceId != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.ResourceIds = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_ResourceId;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            Amazon.Inspector2.AwsEcrContainerSortBy requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortBy = null;
            if (cmdletContext.AwsEcrContainerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortBy = cmdletContext.AwsEcrContainerAggregation_SortBy;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortBy != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.SortBy = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortBy;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
            Amazon.Inspector2.SortOrder requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortOrder = null;
            if (cmdletContext.AwsEcrContainerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortOrder = cmdletContext.AwsEcrContainerAggregation_SortOrder;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortOrder != null)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation.SortOrder = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation_awsEcrContainerAggregation_SortOrder;
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull = false;
            }
             // determine if requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation should be set to null
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregationIsNull)
            {
                requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation = null;
            }
            if (requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation != null)
            {
                request.AggregationRequest.AwsEcrContainerAggregation = requestAggregationRequest_aggregationRequest_AwsEcrContainerAggregation;
                requestAggregationRequestIsNull = false;
            }
             // determine if request.AggregationRequest should be set to null
            if (requestAggregationRequestIsNull)
            {
                request.AggregationRequest = null;
            }
            if (cmdletContext.AggregationType != null)
            {
                request.AggregationType = cmdletContext.AggregationType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Inspector2.Model.ListFindingAggregationsResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.ListFindingAggregationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "ListFindingAggregations");
            try
            {
                #if DESKTOP
                return client.ListFindingAggregations(request);
                #elif CORECLR
                return client.ListFindingAggregationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.StringFilter> AccountId { get; set; }
            public Amazon.Inspector2.AggregationFindingType AccountAggregation_FindingType { get; set; }
            public Amazon.Inspector2.AggregationResourceType AccountAggregation_ResourceType { get; set; }
            public Amazon.Inspector2.AccountSortBy AccountAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder AccountAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AmiAggregation_Ami { get; set; }
            public Amazon.Inspector2.AmiSortBy AmiAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder AmiAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AwsEcrContainerAggregation_Architecture { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AwsEcrContainerAggregation_ImageSha { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AwsEcrContainerAggregation_ImageTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AwsEcrContainerAggregation_Repository { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> AwsEcrContainerAggregation_ResourceId { get; set; }
            public Amazon.Inspector2.AwsEcrContainerSortBy AwsEcrContainerAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder AwsEcrContainerAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> Ec2InstanceAggregation_Ami { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> Ec2InstanceAggregation_InstanceId { get; set; }
            public List<Amazon.Inspector2.Model.MapFilter> Ec2InstanceAggregation_InstanceTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> Ec2InstanceAggregation_OperatingSystem { get; set; }
            public Amazon.Inspector2.Ec2InstanceSortBy Ec2InstanceAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder Ec2InstanceAggregation_SortOrder { get; set; }
            public Amazon.Inspector2.AggregationFindingType FindingTypeAggregation_FindingType { get; set; }
            public Amazon.Inspector2.AggregationResourceType FindingTypeAggregation_ResourceType { get; set; }
            public Amazon.Inspector2.FindingTypeSortBy FindingTypeAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder FindingTypeAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> ImageLayerAggregation_LayerHash { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> ImageLayerAggregation_Repository { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> ImageLayerAggregation_ResourceId { get; set; }
            public Amazon.Inspector2.ImageLayerSortBy ImageLayerAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder ImageLayerAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaFunctionAggregation_FunctionName { get; set; }
            public List<Amazon.Inspector2.Model.MapFilter> LambdaFunctionAggregation_FunctionTag { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaFunctionAggregation_ResourceId { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaFunctionAggregation_Runtime { get; set; }
            public Amazon.Inspector2.LambdaFunctionSortBy LambdaFunctionAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder LambdaFunctionAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaLayerAggregation_FunctionName { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaLayerAggregation_LayerArn { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> LambdaLayerAggregation_ResourceId { get; set; }
            public Amazon.Inspector2.LambdaLayerSortBy LambdaLayerAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder LambdaLayerAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> PackageAggregation_PackageName { get; set; }
            public Amazon.Inspector2.PackageSortBy PackageAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder PackageAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> RepositoryAggregation_Repository { get; set; }
            public Amazon.Inspector2.RepositorySortBy RepositoryAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder RepositoryAggregation_SortOrder { get; set; }
            public Amazon.Inspector2.AggregationFindingType TitleAggregation_FindingType { get; set; }
            public Amazon.Inspector2.AggregationResourceType TitleAggregation_ResourceType { get; set; }
            public Amazon.Inspector2.TitleSortBy TitleAggregation_SortBy { get; set; }
            public Amazon.Inspector2.SortOrder TitleAggregation_SortOrder { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> TitleAggregation_Title { get; set; }
            public List<Amazon.Inspector2.Model.StringFilter> TitleAggregation_VulnerabilityId { get; set; }
            public Amazon.Inspector2.AggregationType AggregationType { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.ListFindingAggregationsResponse, GetINS2FindingAggregationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
