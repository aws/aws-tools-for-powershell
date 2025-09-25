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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Create, or updates, a mapping of users—who have access to a document—to groups.
    /// 
    ///  
    /// <para>
    /// You can also map sub groups to groups. For example, the group "Company Intellectual
    /// Property Teams" includes sub groups "Research" and "Engineering". These sub groups
    /// include their own list of users or people who work in these teams. Only users who
    /// work in research and engineering, and therefore belong in the intellectual property
    /// group, can see top-secret company documents in their Amazon Q Business chat results.
    /// </para><para>
    /// There are two options for creating groups, either passing group members inline or
    /// using an S3 file via the S3PathForGroupMembers field. For inline groups, there is
    /// a limit of 1000 members per group and for provided S3 files there is a limit of 100
    /// thousand members. When creating a group using an S3 file, you provide both an S3 file
    /// and a <c>RoleArn</c> for Amazon Q Buisness to access the file.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "QBUSGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon QBusiness PutGroup API operation.", Operation = new[] {"PutGroup"}, SelectReturnType = typeof(Amazon.QBusiness.Model.PutGroupResponse))]
    [AWSCmdletOutput("None or Amazon.QBusiness.Model.PutGroupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.QBusiness.Model.PutGroupResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteQBUSGroupCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the application in which the user and group mapping belongs.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter S3PathForGroupMembers_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_S3PathForGroupMembers_Bucket")]
        public System.String S3PathForGroupMembers_Bucket { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the data source for which you want to map users to their groups.
        /// This is useful if a group is tied to multiple data sources, but you only want the
        /// group to access documents of a certain data source. For example, the groups "Research",
        /// "Engineering", and "Sales and Marketing" are all tied to the company's documents stored
        /// in the data sources Confluence and Salesforce. However, "Sales and Marketing" team
        /// only needs access to customer-related documents stored in Salesforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>The list that contains your users or sub groups that belong the same group. For example,
        /// the group "Company" includes the user "CEO" and the sub groups "Research", "Engineering",
        /// and "Sales and Marketing".</para>
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
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index in which you want to map users to their groups.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter S3PathForGroupMembers_Key
        /// <summary>
        /// <para>
        /// <para>The name of the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_S3PathForGroupMembers_Key")]
        public System.String S3PathForGroupMembers_Key { get; set; }
        #endregion
        
        #region Parameter GroupMembers_MemberGroup
        /// <summary>
        /// <para>
        /// <para>A list of sub groups that belong to a group. For example, the sub groups "Research",
        /// "Engineering", and "Sales and Marketing" all belong to the group "Company".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_MemberGroups")]
        public Amazon.QBusiness.Model.MemberGroup[] GroupMembers_MemberGroup { get; set; }
        #endregion
        
        #region Parameter GroupMembers_MemberUser
        /// <summary>
        /// <para>
        /// <para>A list of users that belong to a group. For example, a list of interns all belong
        /// to the "Interns" group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_MemberUsers")]
        public Amazon.QBusiness.Model.MemberUser[] GroupMembers_MemberUser { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that has access to the S3 file that
        /// contains your list of users that belong to a group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QBusiness.MembershipType")]
        public Amazon.QBusiness.MembershipType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.PutGroupResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-QBUSGroup (PutGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.PutGroupResponse, WriteQBUSGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceId = this.DataSourceId;
            if (this.GroupMembers_MemberGroup != null)
            {
                context.GroupMembers_MemberGroup = new List<Amazon.QBusiness.Model.MemberGroup>(this.GroupMembers_MemberGroup);
            }
            if (this.GroupMembers_MemberUser != null)
            {
                context.GroupMembers_MemberUser = new List<Amazon.QBusiness.Model.MemberUser>(this.GroupMembers_MemberUser);
            }
            context.S3PathForGroupMembers_Bucket = this.S3PathForGroupMembers_Bucket;
            context.S3PathForGroupMembers_Key = this.S3PathForGroupMembers_Key;
            context.GroupName = this.GroupName;
            #if MODULAR
            if (this.GroupName == null && ParameterWasBound(nameof(this.GroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.QBusiness.Model.PutGroupRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            
             // populate GroupMembers
            var requestGroupMembersIsNull = true;
            request.GroupMembers = new Amazon.QBusiness.Model.GroupMembers();
            List<Amazon.QBusiness.Model.MemberGroup> requestGroupMembers_groupMembers_MemberGroup = null;
            if (cmdletContext.GroupMembers_MemberGroup != null)
            {
                requestGroupMembers_groupMembers_MemberGroup = cmdletContext.GroupMembers_MemberGroup;
            }
            if (requestGroupMembers_groupMembers_MemberGroup != null)
            {
                request.GroupMembers.MemberGroups = requestGroupMembers_groupMembers_MemberGroup;
                requestGroupMembersIsNull = false;
            }
            List<Amazon.QBusiness.Model.MemberUser> requestGroupMembers_groupMembers_MemberUser = null;
            if (cmdletContext.GroupMembers_MemberUser != null)
            {
                requestGroupMembers_groupMembers_MemberUser = cmdletContext.GroupMembers_MemberUser;
            }
            if (requestGroupMembers_groupMembers_MemberUser != null)
            {
                request.GroupMembers.MemberUsers = requestGroupMembers_groupMembers_MemberUser;
                requestGroupMembersIsNull = false;
            }
            Amazon.QBusiness.Model.S3 requestGroupMembers_groupMembers_S3PathForGroupMembers = null;
            
             // populate S3PathForGroupMembers
            var requestGroupMembers_groupMembers_S3PathForGroupMembersIsNull = true;
            requestGroupMembers_groupMembers_S3PathForGroupMembers = new Amazon.QBusiness.Model.S3();
            System.String requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Bucket = null;
            if (cmdletContext.S3PathForGroupMembers_Bucket != null)
            {
                requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Bucket = cmdletContext.S3PathForGroupMembers_Bucket;
            }
            if (requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Bucket != null)
            {
                requestGroupMembers_groupMembers_S3PathForGroupMembers.Bucket = requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Bucket;
                requestGroupMembers_groupMembers_S3PathForGroupMembersIsNull = false;
            }
            System.String requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Key = null;
            if (cmdletContext.S3PathForGroupMembers_Key != null)
            {
                requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Key = cmdletContext.S3PathForGroupMembers_Key;
            }
            if (requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Key != null)
            {
                requestGroupMembers_groupMembers_S3PathForGroupMembers.Key = requestGroupMembers_groupMembers_S3PathForGroupMembers_s3PathForGroupMembers_Key;
                requestGroupMembers_groupMembers_S3PathForGroupMembersIsNull = false;
            }
             // determine if requestGroupMembers_groupMembers_S3PathForGroupMembers should be set to null
            if (requestGroupMembers_groupMembers_S3PathForGroupMembersIsNull)
            {
                requestGroupMembers_groupMembers_S3PathForGroupMembers = null;
            }
            if (requestGroupMembers_groupMembers_S3PathForGroupMembers != null)
            {
                request.GroupMembers.S3PathForGroupMembers = requestGroupMembers_groupMembers_S3PathForGroupMembers;
                requestGroupMembersIsNull = false;
            }
             // determine if request.GroupMembers should be set to null
            if (requestGroupMembersIsNull)
            {
                request.GroupMembers = null;
            }
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QBusiness.Model.PutGroupResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.PutGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "PutGroup");
            try
            {
                #if DESKTOP
                return client.PutGroup(request);
                #elif CORECLR
                return client.PutGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String DataSourceId { get; set; }
            public List<Amazon.QBusiness.Model.MemberGroup> GroupMembers_MemberGroup { get; set; }
            public List<Amazon.QBusiness.Model.MemberUser> GroupMembers_MemberUser { get; set; }
            public System.String S3PathForGroupMembers_Bucket { get; set; }
            public System.String S3PathForGroupMembers_Key { get; set; }
            public System.String GroupName { get; set; }
            public System.String IndexId { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.QBusiness.MembershipType Type { get; set; }
            public System.Func<Amazon.QBusiness.Model.PutGroupResponse, WriteQBUSGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
