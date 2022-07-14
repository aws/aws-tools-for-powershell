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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Maps users to their groups so that you only need to provide the user ID when you issue
    /// the query.
    /// 
    ///  
    /// <para>
    /// You can also map sub groups to groups. For example, the group "Company Intellectual
    /// Property Teams" includes sub groups "Research" and "Engineering". These sub groups
    /// include their own list of users or people who work in these teams. Only users who
    /// work in research and engineering, and therefore belong in the intellectual property
    /// group, can see top-secret company documents in their search results.
    /// </para><para>
    /// This is useful for user context filtering, where search results are filtered based
    /// on the user or their group access to documents. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/user-context-filter.html">Filtering
    /// on user context</a>.
    /// </para><para>
    /// If more than five <code>PUT</code> actions for a group are currently processing, a
    /// validation exception is thrown.
    /// </para><para><code>PutPrincipalMapping</code> is currently not supported in the Amazon Web Services
    /// GovCloud (US-West) region.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "KNDRPrincipalMapping", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra PutPrincipalMapping API operation.", Operation = new[] {"PutPrincipalMapping"}, SelectReturnType = typeof(Amazon.Kendra.Model.PutPrincipalMappingResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.PutPrincipalMappingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.PutPrincipalMappingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteKNDRPrincipalMappingCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        #region Parameter S3PathforGroupMembers_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket that contains the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_S3PathforGroupMembers_Bucket")]
        public System.String S3PathforGroupMembers_Bucket { get; set; }
        #endregion
        
        #region Parameter DataSourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the data source you want to map users to their groups.</para><para>This is useful if a group is tied to multiple data sources, but you only want the
        /// group to access documents of a certain data source. For example, the groups "Research",
        /// "Engineering", and "Sales and Marketing" are all tied to the company's documents stored
        /// in the data sources Confluence and Salesforce. However, "Sales and Marketing" team
        /// only needs access to customer-related documents stored in Salesforce.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceId { get; set; }
        #endregion
        
        #region Parameter GroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the group you want to map its users to.</para>
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
        public System.String GroupId { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index you want to map users to their groups.</para>
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
        
        #region Parameter S3PathforGroupMembers_Key
        /// <summary>
        /// <para>
        /// <para>The name of the file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupMembers_S3PathforGroupMembers_Key")]
        public System.String S3PathforGroupMembers_Key { get; set; }
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
        public Amazon.Kendra.Model.MemberGroup[] GroupMembers_MemberGroup { get; set; }
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
        public Amazon.Kendra.Model.MemberUser[] GroupMembers_MemberUser { get; set; }
        #endregion
        
        #region Parameter OrderingId
        /// <summary>
        /// <para>
        /// <para>The timestamp identifier you specify to ensure Amazon Kendra does not override the
        /// latest <code>PUT</code> action with previous actions. The highest number ID, which
        /// is the ordering ID, is the latest action you want to process and apply on top of other
        /// actions with lower number IDs. This prevents previous actions with lower number IDs
        /// from possibly overriding the latest action.</para><para>The ordering ID can be the UNIX time of the last update you made to a group members
        /// list. You would then provide this list when calling <code>PutPrincipalMapping</code>.
        /// This ensures your <code>PUT</code> action for that updated group with the latest members
        /// list doesn't get overwritten by earlier <code>PUT</code> actions for the same group
        /// which are yet to be processed.</para><para>The default ordering ID is the current UNIX time in milliseconds that the action was
        /// received by Amazon Kendra.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? OrderingId { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role that has access to the S3 file that contains
        /// your list of users or sub groups that belong to a group.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html#iam-roles-ds">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.PutPrincipalMappingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-KNDRPrincipalMapping (PutPrincipalMapping)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.PutPrincipalMappingResponse, WriteKNDRPrincipalMappingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataSourceId = this.DataSourceId;
            context.GroupId = this.GroupId;
            #if MODULAR
            if (this.GroupId == null && ParameterWasBound(nameof(this.GroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GroupMembers_MemberGroup != null)
            {
                context.GroupMembers_MemberGroup = new List<Amazon.Kendra.Model.MemberGroup>(this.GroupMembers_MemberGroup);
            }
            if (this.GroupMembers_MemberUser != null)
            {
                context.GroupMembers_MemberUser = new List<Amazon.Kendra.Model.MemberUser>(this.GroupMembers_MemberUser);
            }
            context.S3PathforGroupMembers_Bucket = this.S3PathforGroupMembers_Bucket;
            context.S3PathforGroupMembers_Key = this.S3PathforGroupMembers_Key;
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrderingId = this.OrderingId;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Kendra.Model.PutPrincipalMappingRequest();
            
            if (cmdletContext.DataSourceId != null)
            {
                request.DataSourceId = cmdletContext.DataSourceId;
            }
            if (cmdletContext.GroupId != null)
            {
                request.GroupId = cmdletContext.GroupId;
            }
            
             // populate GroupMembers
            var requestGroupMembersIsNull = true;
            request.GroupMembers = new Amazon.Kendra.Model.GroupMembers();
            List<Amazon.Kendra.Model.MemberGroup> requestGroupMembers_groupMembers_MemberGroup = null;
            if (cmdletContext.GroupMembers_MemberGroup != null)
            {
                requestGroupMembers_groupMembers_MemberGroup = cmdletContext.GroupMembers_MemberGroup;
            }
            if (requestGroupMembers_groupMembers_MemberGroup != null)
            {
                request.GroupMembers.MemberGroups = requestGroupMembers_groupMembers_MemberGroup;
                requestGroupMembersIsNull = false;
            }
            List<Amazon.Kendra.Model.MemberUser> requestGroupMembers_groupMembers_MemberUser = null;
            if (cmdletContext.GroupMembers_MemberUser != null)
            {
                requestGroupMembers_groupMembers_MemberUser = cmdletContext.GroupMembers_MemberUser;
            }
            if (requestGroupMembers_groupMembers_MemberUser != null)
            {
                request.GroupMembers.MemberUsers = requestGroupMembers_groupMembers_MemberUser;
                requestGroupMembersIsNull = false;
            }
            Amazon.Kendra.Model.S3Path requestGroupMembers_groupMembers_S3PathforGroupMembers = null;
            
             // populate S3PathforGroupMembers
            var requestGroupMembers_groupMembers_S3PathforGroupMembersIsNull = true;
            requestGroupMembers_groupMembers_S3PathforGroupMembers = new Amazon.Kendra.Model.S3Path();
            System.String requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Bucket = null;
            if (cmdletContext.S3PathforGroupMembers_Bucket != null)
            {
                requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Bucket = cmdletContext.S3PathforGroupMembers_Bucket;
            }
            if (requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Bucket != null)
            {
                requestGroupMembers_groupMembers_S3PathforGroupMembers.Bucket = requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Bucket;
                requestGroupMembers_groupMembers_S3PathforGroupMembersIsNull = false;
            }
            System.String requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Key = null;
            if (cmdletContext.S3PathforGroupMembers_Key != null)
            {
                requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Key = cmdletContext.S3PathforGroupMembers_Key;
            }
            if (requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Key != null)
            {
                requestGroupMembers_groupMembers_S3PathforGroupMembers.Key = requestGroupMembers_groupMembers_S3PathforGroupMembers_s3PathforGroupMembers_Key;
                requestGroupMembers_groupMembers_S3PathforGroupMembersIsNull = false;
            }
             // determine if requestGroupMembers_groupMembers_S3PathforGroupMembers should be set to null
            if (requestGroupMembers_groupMembers_S3PathforGroupMembersIsNull)
            {
                requestGroupMembers_groupMembers_S3PathforGroupMembers = null;
            }
            if (requestGroupMembers_groupMembers_S3PathforGroupMembers != null)
            {
                request.GroupMembers.S3PathforGroupMembers = requestGroupMembers_groupMembers_S3PathforGroupMembers;
                requestGroupMembersIsNull = false;
            }
             // determine if request.GroupMembers should be set to null
            if (requestGroupMembersIsNull)
            {
                request.GroupMembers = null;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.OrderingId != null)
            {
                request.OrderingId = cmdletContext.OrderingId.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Kendra.Model.PutPrincipalMappingResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.PutPrincipalMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "PutPrincipalMapping");
            try
            {
                #if DESKTOP
                return client.PutPrincipalMapping(request);
                #elif CORECLR
                return client.PutPrincipalMappingAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSourceId { get; set; }
            public System.String GroupId { get; set; }
            public List<Amazon.Kendra.Model.MemberGroup> GroupMembers_MemberGroup { get; set; }
            public List<Amazon.Kendra.Model.MemberUser> GroupMembers_MemberUser { get; set; }
            public System.String S3PathforGroupMembers_Bucket { get; set; }
            public System.String S3PathforGroupMembers_Key { get; set; }
            public System.String IndexId { get; set; }
            public System.Int64? OrderingId { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Kendra.Model.PutPrincipalMappingResponse, WriteKNDRPrincipalMappingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
