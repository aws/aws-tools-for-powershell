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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// Creates a new S3 Storage Lens group and associates it with the specified Amazon Web
    /// Services account ID. An S3 Storage Lens group is a custom grouping of objects based
    /// on prefix, suffix, object tags, object size, object age, or a combination of these
    /// filters. For each Storage Lens group that you’ve created, you can also optionally
    /// add Amazon Web Services resource tags. For more information about S3 Storage Lens
    /// groups, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/storage-lens-groups-overview.html">Working
    /// with S3 Storage Lens groups</a>.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the permission to perform the <c>s3:CreateStorageLensGroup</c>
    /// action. If you’re trying to create a Storage Lens group with Amazon Web Services resource
    /// tags, you must also have permission to perform the <c>s3:TagResource</c> action. For
    /// more information about the required Storage Lens Groups permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/storage_lens_iam_permissions.html#storage_lens_groups_permissions">Setting
    /// account permissions to use S3 Storage Lens groups</a>.
    /// </para><para>
    /// For information about Storage Lens groups errors, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/ErrorResponses.html#S3LensErrorCodeList">List
    /// of Amazon S3 Storage Lens error codes</a>.
    /// </para><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "S3CStorageLensGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateStorageLensGroup API operation.", Operation = new[] {"CreateStorageLensGroup"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateStorageLensGroupResponse))]
    [AWSCmdletOutput("None or Amazon.S3Control.Model.CreateStorageLensGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3Control.Model.CreateStorageLensGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewS3CStorageLensGroupCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID that the Storage Lens group is created from and
        /// associated with. </para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object size in Bytes. The value must be a positive number,
        /// greater than 0 and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object size in Bytes. The value must be a positive number,
        /// greater than 0 and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object size in Bytes. The value must be a positive number,
        /// greater than 0 and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object size in Bytes. The value must be a positive number,
        /// greater than the minimum object size and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchObjectSize_BytesLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object size in Bytes. The value must be a positive number,
        /// greater than the minimum object size and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_MatchObjectSize_BytesLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object size in Bytes. The value must be a positive number,
        /// greater than the minimum object size and less than 5 TB. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object age in days. Must be a positive whole number, greater
        /// than the minimum object age and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object age in days. Must be a positive whole number, greater
        /// than the minimum object age and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum object age in days. Must be a positive whole number, greater
        /// than the minimum object age and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object age in days. The value must be a positive whole number,
        /// greater than 0 and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchObjectAge_DaysLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object age in days. The value must be a positive whole number,
        /// greater than 0 and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_MatchObjectAge_DaysLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan
        /// <summary>
        /// <para>
        /// <para> Specifies the minimum object age in days. The value must be a positive whole number,
        /// greater than 0 and less than or equal to 2,147,483,647. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchAnyPrefix
        /// <summary>
        /// <para>
        /// <para> Contains a list of prefixes. At least one prefix must be specified. Up to 10 prefixes
        /// are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_And_MatchAnyPrefix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchAnyPrefix
        /// <summary>
        /// <para>
        /// <para> Contains a list of prefixes. At least one prefix must be specified. Up to 10 prefixes
        /// are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_MatchAnyPrefix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchAnyPrefix
        /// <summary>
        /// <para>
        /// <para> Filters objects that match any of the specified prefixes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_Or_MatchAnyPrefix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchAnySuffix
        /// <summary>
        /// <para>
        /// <para> Contains a list of suffixes. At least one suffix must be specified. Up to 10 suffixes
        /// are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_And_MatchAnySuffix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchAnySuffix
        /// <summary>
        /// <para>
        /// <para> Contains a list of suffixes. At least one suffix must be specified. Up to 10 suffixes
        /// are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_MatchAnySuffix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchAnySuffix
        /// <summary>
        /// <para>
        /// <para> Filters objects that match any of the specified suffixes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StorageLensGroup_Filter_Or_MatchAnySuffix { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_And_MatchAnyTag
        /// <summary>
        /// <para>
        /// <para> Contains the list of object tags. At least one object tag must be specified. Up to
        /// 10 object tags are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3Control.Model.S3Tag[] StorageLensGroup_Filter_And_MatchAnyTag { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_MatchAnyTag
        /// <summary>
        /// <para>
        /// <para> Contains the list of S3 object tags. At least one object tag must be specified. Up
        /// to 10 object tags are allowed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3Control.Model.S3Tag[] StorageLensGroup_Filter_MatchAnyTag { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Filter_Or_MatchAnyTag
        /// <summary>
        /// <para>
        /// <para> Filters objects that match any of the specified S3 object tags. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3Control.Model.S3Tag[] StorageLensGroup_Filter_Or_MatchAnyTag { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_Name
        /// <summary>
        /// <para>
        /// <para> Contains the name of the Storage Lens group. </para>
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
        public System.String StorageLensGroup_Name { get; set; }
        #endregion
        
        #region Parameter StorageLensGroup_StorageLensGroupArn
        /// <summary>
        /// <para>
        /// <para> Contains the Amazon Resource Name (ARN) of the Storage Lens group. This property
        /// is read-only. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageLensGroup_StorageLensGroupArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services resource tags that you're adding to your Storage Lens group.
        /// This parameter is optional. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateStorageLensGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "s3v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CStorageLensGroup (CreateStorageLensGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateStorageLensGroupResponse, NewS3CStorageLensGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StorageLensGroup_Filter_And_MatchAnyPrefix != null)
            {
                context.StorageLensGroup_Filter_And_MatchAnyPrefix = new List<System.String>(this.StorageLensGroup_Filter_And_MatchAnyPrefix);
            }
            if (this.StorageLensGroup_Filter_And_MatchAnySuffix != null)
            {
                context.StorageLensGroup_Filter_And_MatchAnySuffix = new List<System.String>(this.StorageLensGroup_Filter_And_MatchAnySuffix);
            }
            if (this.StorageLensGroup_Filter_And_MatchAnyTag != null)
            {
                context.StorageLensGroup_Filter_And_MatchAnyTag = new List<Amazon.S3Control.Model.S3Tag>(this.StorageLensGroup_Filter_And_MatchAnyTag);
            }
            context.StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan = this.StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan;
            context.StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan = this.StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan;
            context.StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan = this.StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan;
            context.StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan = this.StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan;
            if (this.StorageLensGroup_Filter_MatchAnyPrefix != null)
            {
                context.StorageLensGroup_Filter_MatchAnyPrefix = new List<System.String>(this.StorageLensGroup_Filter_MatchAnyPrefix);
            }
            if (this.StorageLensGroup_Filter_MatchAnySuffix != null)
            {
                context.StorageLensGroup_Filter_MatchAnySuffix = new List<System.String>(this.StorageLensGroup_Filter_MatchAnySuffix);
            }
            if (this.StorageLensGroup_Filter_MatchAnyTag != null)
            {
                context.StorageLensGroup_Filter_MatchAnyTag = new List<Amazon.S3Control.Model.S3Tag>(this.StorageLensGroup_Filter_MatchAnyTag);
            }
            context.StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan = this.StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan;
            context.StorageLensGroup_Filter_MatchObjectAge_DaysLessThan = this.StorageLensGroup_Filter_MatchObjectAge_DaysLessThan;
            context.StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan = this.StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan;
            context.StorageLensGroup_Filter_MatchObjectSize_BytesLessThan = this.StorageLensGroup_Filter_MatchObjectSize_BytesLessThan;
            if (this.StorageLensGroup_Filter_Or_MatchAnyPrefix != null)
            {
                context.StorageLensGroup_Filter_Or_MatchAnyPrefix = new List<System.String>(this.StorageLensGroup_Filter_Or_MatchAnyPrefix);
            }
            if (this.StorageLensGroup_Filter_Or_MatchAnySuffix != null)
            {
                context.StorageLensGroup_Filter_Or_MatchAnySuffix = new List<System.String>(this.StorageLensGroup_Filter_Or_MatchAnySuffix);
            }
            if (this.StorageLensGroup_Filter_Or_MatchAnyTag != null)
            {
                context.StorageLensGroup_Filter_Or_MatchAnyTag = new List<Amazon.S3Control.Model.S3Tag>(this.StorageLensGroup_Filter_Or_MatchAnyTag);
            }
            context.StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan = this.StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan;
            context.StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan = this.StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan;
            context.StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan = this.StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan;
            context.StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan = this.StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan;
            context.StorageLensGroup_Name = this.StorageLensGroup_Name;
            #if MODULAR
            if (this.StorageLensGroup_Name == null && ParameterWasBound(nameof(this.StorageLensGroup_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageLensGroup_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageLensGroup_StorageLensGroupArn = this.StorageLensGroup_StorageLensGroupArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.Tag>(this.Tag);
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
            var request = new Amazon.S3Control.Model.CreateStorageLensGroupRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate StorageLensGroup
            var requestStorageLensGroupIsNull = true;
            request.StorageLensGroup = new Amazon.S3Control.Model.StorageLensGroup();
            System.String requestStorageLensGroup_storageLensGroup_Name = null;
            if (cmdletContext.StorageLensGroup_Name != null)
            {
                requestStorageLensGroup_storageLensGroup_Name = cmdletContext.StorageLensGroup_Name;
            }
            if (requestStorageLensGroup_storageLensGroup_Name != null)
            {
                request.StorageLensGroup.Name = requestStorageLensGroup_storageLensGroup_Name;
                requestStorageLensGroupIsNull = false;
            }
            System.String requestStorageLensGroup_storageLensGroup_StorageLensGroupArn = null;
            if (cmdletContext.StorageLensGroup_StorageLensGroupArn != null)
            {
                requestStorageLensGroup_storageLensGroup_StorageLensGroupArn = cmdletContext.StorageLensGroup_StorageLensGroupArn;
            }
            if (requestStorageLensGroup_storageLensGroup_StorageLensGroupArn != null)
            {
                request.StorageLensGroup.StorageLensGroupArn = requestStorageLensGroup_storageLensGroup_StorageLensGroupArn;
                requestStorageLensGroupIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensGroupFilter requestStorageLensGroup_storageLensGroup_Filter = null;
            
             // populate Filter
            var requestStorageLensGroup_storageLensGroup_FilterIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter = new Amazon.S3Control.Model.StorageLensGroupFilter();
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyPrefix = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyPrefix = cmdletContext.StorageLensGroup_Filter_MatchAnyPrefix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.MatchAnyPrefix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyPrefix;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnySuffix = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnySuffix = cmdletContext.StorageLensGroup_Filter_MatchAnySuffix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.MatchAnySuffix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnySuffix;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            List<Amazon.S3Control.Model.S3Tag> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyTag = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyTag = cmdletContext.StorageLensGroup_Filter_MatchAnyTag;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.MatchAnyTag = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchAnyTag;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectAge requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge = null;
            
             // populate MatchObjectAge
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAgeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge = new Amazon.S3Control.Model.MatchObjectAge();
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysGreaterThan = cmdletContext.StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge.DaysGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAgeIsNull = false;
            }
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysLessThan = cmdletContext.StorageLensGroup_Filter_MatchObjectAge_DaysLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge.DaysLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge_storageLensGroup_Filter_MatchObjectAge_DaysLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAgeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAgeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.MatchObjectAge = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectAge;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectSize requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize = null;
            
             // populate MatchObjectSize
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSizeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize = new Amazon.S3Control.Model.MatchObjectSize();
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesGreaterThan = cmdletContext.StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize.BytesGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSizeIsNull = false;
            }
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesLessThan = cmdletContext.StorageLensGroup_Filter_MatchObjectSize_BytesLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize.BytesLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize_storageLensGroup_Filter_MatchObjectSize_BytesLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSizeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSizeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.MatchObjectSize = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_MatchObjectSize;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensGroupAndOperator requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And = null;
            
             // populate And
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And = new Amazon.S3Control.Model.StorageLensGroupAndOperator();
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyPrefix = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyPrefix = cmdletContext.StorageLensGroup_Filter_And_MatchAnyPrefix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And.MatchAnyPrefix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyPrefix;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = false;
            }
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnySuffix = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnySuffix = cmdletContext.StorageLensGroup_Filter_And_MatchAnySuffix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And.MatchAnySuffix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnySuffix;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = false;
            }
            List<Amazon.S3Control.Model.S3Tag> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyTag = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyTag = cmdletContext.StorageLensGroup_Filter_And_MatchAnyTag;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And.MatchAnyTag = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchAnyTag;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectAge requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge = null;
            
             // populate MatchObjectAge
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAgeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge = new Amazon.S3Control.Model.MatchObjectAge();
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan = cmdletContext.StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge.DaysGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAgeIsNull = false;
            }
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysLessThan = cmdletContext.StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge.DaysLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge_storageLensGroup_Filter_And_MatchObjectAge_DaysLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAgeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAgeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And.MatchObjectAge = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectAge;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectSize requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize = null;
            
             // populate MatchObjectSize
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSizeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize = new Amazon.S3Control.Model.MatchObjectSize();
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan = cmdletContext.StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize.BytesGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSizeIsNull = false;
            }
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesLessThan = cmdletContext.StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize.BytesLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize_storageLensGroup_Filter_And_MatchObjectSize_BytesLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSizeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSizeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And.MatchObjectSize = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And_storageLensGroup_Filter_And_MatchObjectSize;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_AndIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.And = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_And;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
            Amazon.S3Control.Model.StorageLensGroupOrOperator requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or = null;
            
             // populate Or
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or = new Amazon.S3Control.Model.StorageLensGroupOrOperator();
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyPrefix = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyPrefix = cmdletContext.StorageLensGroup_Filter_Or_MatchAnyPrefix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyPrefix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or.MatchAnyPrefix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyPrefix;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = false;
            }
            List<System.String> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnySuffix = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnySuffix = cmdletContext.StorageLensGroup_Filter_Or_MatchAnySuffix;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnySuffix != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or.MatchAnySuffix = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnySuffix;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = false;
            }
            List<Amazon.S3Control.Model.S3Tag> requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyTag = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyTag = cmdletContext.StorageLensGroup_Filter_Or_MatchAnyTag;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyTag != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or.MatchAnyTag = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchAnyTag;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectAge requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge = null;
            
             // populate MatchObjectAge
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAgeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge = new Amazon.S3Control.Model.MatchObjectAge();
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan = cmdletContext.StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge.DaysGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAgeIsNull = false;
            }
            System.Int32? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan = cmdletContext.StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge.DaysLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge_storageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAgeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAgeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or.MatchObjectAge = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectAge;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = false;
            }
            Amazon.S3Control.Model.MatchObjectSize requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize = null;
            
             // populate MatchObjectSize
            var requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSizeIsNull = true;
            requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize = new Amazon.S3Control.Model.MatchObjectSize();
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan = cmdletContext.StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize.BytesGreaterThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSizeIsNull = false;
            }
            System.Int64? requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan = null;
            if (cmdletContext.StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan = cmdletContext.StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan.Value;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize.BytesLessThan = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize_storageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan.Value;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSizeIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSizeIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or.MatchObjectSize = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or_storageLensGroup_Filter_Or_MatchObjectSize;
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or should be set to null
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_OrIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or != null)
            {
                requestStorageLensGroup_storageLensGroup_Filter.Or = requestStorageLensGroup_storageLensGroup_Filter_storageLensGroup_Filter_Or;
                requestStorageLensGroup_storageLensGroup_FilterIsNull = false;
            }
             // determine if requestStorageLensGroup_storageLensGroup_Filter should be set to null
            if (requestStorageLensGroup_storageLensGroup_FilterIsNull)
            {
                requestStorageLensGroup_storageLensGroup_Filter = null;
            }
            if (requestStorageLensGroup_storageLensGroup_Filter != null)
            {
                request.StorageLensGroup.Filter = requestStorageLensGroup_storageLensGroup_Filter;
                requestStorageLensGroupIsNull = false;
            }
             // determine if request.StorageLensGroup should be set to null
            if (requestStorageLensGroupIsNull)
            {
                request.StorageLensGroup = null;
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
        
        private Amazon.S3Control.Model.CreateStorageLensGroupResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateStorageLensGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateStorageLensGroup");
            try
            {
                #if DESKTOP
                return client.CreateStorageLensGroup(request);
                #elif CORECLR
                return client.CreateStorageLensGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public List<System.String> StorageLensGroup_Filter_And_MatchAnyPrefix { get; set; }
            public List<System.String> StorageLensGroup_Filter_And_MatchAnySuffix { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> StorageLensGroup_Filter_And_MatchAnyTag { get; set; }
            public System.Int32? StorageLensGroup_Filter_And_MatchObjectAge_DaysGreaterThan { get; set; }
            public System.Int32? StorageLensGroup_Filter_And_MatchObjectAge_DaysLessThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_And_MatchObjectSize_BytesGreaterThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_And_MatchObjectSize_BytesLessThan { get; set; }
            public List<System.String> StorageLensGroup_Filter_MatchAnyPrefix { get; set; }
            public List<System.String> StorageLensGroup_Filter_MatchAnySuffix { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> StorageLensGroup_Filter_MatchAnyTag { get; set; }
            public System.Int32? StorageLensGroup_Filter_MatchObjectAge_DaysGreaterThan { get; set; }
            public System.Int32? StorageLensGroup_Filter_MatchObjectAge_DaysLessThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_MatchObjectSize_BytesGreaterThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_MatchObjectSize_BytesLessThan { get; set; }
            public List<System.String> StorageLensGroup_Filter_Or_MatchAnyPrefix { get; set; }
            public List<System.String> StorageLensGroup_Filter_Or_MatchAnySuffix { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> StorageLensGroup_Filter_Or_MatchAnyTag { get; set; }
            public System.Int32? StorageLensGroup_Filter_Or_MatchObjectAge_DaysGreaterThan { get; set; }
            public System.Int32? StorageLensGroup_Filter_Or_MatchObjectAge_DaysLessThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_Or_MatchObjectSize_BytesGreaterThan { get; set; }
            public System.Int64? StorageLensGroup_Filter_Or_MatchObjectSize_BytesLessThan { get; set; }
            public System.String StorageLensGroup_Name { get; set; }
            public System.String StorageLensGroup_StorageLensGroupArn { get; set; }
            public List<Amazon.S3Control.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateStorageLensGroupResponse, NewS3CStorageLensGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
