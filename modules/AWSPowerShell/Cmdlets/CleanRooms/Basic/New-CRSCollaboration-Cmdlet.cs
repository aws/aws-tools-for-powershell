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
using Amazon.CleanRooms;
using Amazon.CleanRooms.Model;

namespace Amazon.PowerShell.Cmdlets.CRS
{
    /// <summary>
    /// Creates a new collaboration.
    /// </summary>
    [Cmdlet("New", "CRSCollaboration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CleanRooms.Model.Collaboration")]
    [AWSCmdlet("Calls the AWS Clean Rooms Service CreateCollaboration API operation.", Operation = new[] {"CreateCollaboration"}, SelectReturnType = typeof(Amazon.CleanRooms.Model.CreateCollaborationResponse))]
    [AWSCmdletOutput("Amazon.CleanRooms.Model.Collaboration or Amazon.CleanRooms.Model.CreateCollaborationResponse",
        "This cmdlet returns an Amazon.CleanRooms.Model.Collaboration object.",
        "The service call response (type Amazon.CleanRooms.Model.CreateCollaborationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCRSCollaborationCmdlet : AmazonCleanRoomsClientCmdlet, IExecutor
    {
        
        #region Parameter DataEncryptionMetadata_AllowCleartext
        /// <summary>
        /// <para>
        /// <para>Indicates whether encrypted tables can contain cleartext data (true) or are to cryptographically
        /// process every column (false).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataEncryptionMetadata_AllowCleartext { get; set; }
        #endregion
        
        #region Parameter DataEncryptionMetadata_AllowDuplicate
        /// <summary>
        /// <para>
        /// <para>Indicates whether Fingerprint columns can contain duplicate entries (true) or are
        /// to contain only non-repeated values (false).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataEncryptionMetadata_AllowDuplicates")]
        public System.Boolean? DataEncryptionMetadata_AllowDuplicate { get; set; }
        #endregion
        
        #region Parameter DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName
        /// <summary>
        /// <para>
        /// <para>Indicates whether Fingerprint columns can be joined on any other Fingerprint column
        /// with a different name (true) or can only be joined on Fingerprint columns of the same
        /// name (false).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentNames")]
        public System.Boolean? DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName { get; set; }
        #endregion
        
        #region Parameter CreatorDisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the collaboration creator.</para>
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
        public System.String CreatorDisplayName { get; set; }
        #endregion
        
        #region Parameter CreatorMemberAbility
        /// <summary>
        /// <para>
        /// <para>The abilities granted to the collaboration creator.</para>
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
        [Alias("CreatorMemberAbilities")]
        public System.String[] CreatorMemberAbility { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the collaboration provided by the collaboration owner.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Member
        /// <summary>
        /// <para>
        /// <para>A list of initial members, not including the creator. This list is immutable.</para>
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
        [Alias("Members")]
        public Amazon.CleanRooms.Model.MemberSpecification[] Member { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The display name for a collaboration.</para>
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
        
        #region Parameter DataEncryptionMetadata_PreserveNull
        /// <summary>
        /// <para>
        /// <para>Indicates whether NULL values are to be copied as NULL to encrypted tables (true)
        /// or cryptographically processed (false).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataEncryptionMetadata_PreserveNulls")]
        public System.Boolean? DataEncryptionMetadata_PreserveNull { get; set; }
        #endregion
        
        #region Parameter QueryLogStatus
        /// <summary>
        /// <para>
        /// <para>An indicator as to whether query logging has been enabled or disabled for the collaboration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CleanRooms.CollaborationQueryLogStatus")]
        public Amazon.CleanRooms.CollaborationQueryLogStatus QueryLogStatus { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional label that you can assign to a resource when you create it. Each tag consists
        /// of a key and an optional value, both of which you define. When you use tagging, you
        /// can also use tag-based access control in IAM policies to control access to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Collaboration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRooms.Model.CreateCollaborationResponse).
        /// Specifying the name of a property of type Amazon.CleanRooms.Model.CreateCollaborationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Collaboration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CRSCollaboration (CreateCollaboration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRooms.Model.CreateCollaborationResponse, NewCRSCollaborationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatorDisplayName = this.CreatorDisplayName;
            #if MODULAR
            if (this.CreatorDisplayName == null && ParameterWasBound(nameof(this.CreatorDisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter CreatorDisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CreatorMemberAbility != null)
            {
                context.CreatorMemberAbility = new List<System.String>(this.CreatorMemberAbility);
            }
            #if MODULAR
            if (this.CreatorMemberAbility == null && ParameterWasBound(nameof(this.CreatorMemberAbility)))
            {
                WriteWarning("You are passing $null as a value for parameter CreatorMemberAbility which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataEncryptionMetadata_AllowCleartext = this.DataEncryptionMetadata_AllowCleartext;
            context.DataEncryptionMetadata_AllowDuplicate = this.DataEncryptionMetadata_AllowDuplicate;
            context.DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName = this.DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName;
            context.DataEncryptionMetadata_PreserveNull = this.DataEncryptionMetadata_PreserveNull;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Member != null)
            {
                context.Member = new List<Amazon.CleanRooms.Model.MemberSpecification>(this.Member);
            }
            #if MODULAR
            if (this.Member == null && ParameterWasBound(nameof(this.Member)))
            {
                WriteWarning("You are passing $null as a value for parameter Member which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryLogStatus = this.QueryLogStatus;
            #if MODULAR
            if (this.QueryLogStatus == null && ParameterWasBound(nameof(this.QueryLogStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryLogStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.CleanRooms.Model.CreateCollaborationRequest();
            
            if (cmdletContext.CreatorDisplayName != null)
            {
                request.CreatorDisplayName = cmdletContext.CreatorDisplayName;
            }
            if (cmdletContext.CreatorMemberAbility != null)
            {
                request.CreatorMemberAbilities = cmdletContext.CreatorMemberAbility;
            }
            
             // populate DataEncryptionMetadata
            var requestDataEncryptionMetadataIsNull = true;
            request.DataEncryptionMetadata = new Amazon.CleanRooms.Model.DataEncryptionMetadata();
            System.Boolean? requestDataEncryptionMetadata_dataEncryptionMetadata_AllowCleartext = null;
            if (cmdletContext.DataEncryptionMetadata_AllowCleartext != null)
            {
                requestDataEncryptionMetadata_dataEncryptionMetadata_AllowCleartext = cmdletContext.DataEncryptionMetadata_AllowCleartext.Value;
            }
            if (requestDataEncryptionMetadata_dataEncryptionMetadata_AllowCleartext != null)
            {
                request.DataEncryptionMetadata.AllowCleartext = requestDataEncryptionMetadata_dataEncryptionMetadata_AllowCleartext.Value;
                requestDataEncryptionMetadataIsNull = false;
            }
            System.Boolean? requestDataEncryptionMetadata_dataEncryptionMetadata_AllowDuplicate = null;
            if (cmdletContext.DataEncryptionMetadata_AllowDuplicate != null)
            {
                requestDataEncryptionMetadata_dataEncryptionMetadata_AllowDuplicate = cmdletContext.DataEncryptionMetadata_AllowDuplicate.Value;
            }
            if (requestDataEncryptionMetadata_dataEncryptionMetadata_AllowDuplicate != null)
            {
                request.DataEncryptionMetadata.AllowDuplicates = requestDataEncryptionMetadata_dataEncryptionMetadata_AllowDuplicate.Value;
                requestDataEncryptionMetadataIsNull = false;
            }
            System.Boolean? requestDataEncryptionMetadata_dataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName = null;
            if (cmdletContext.DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName != null)
            {
                requestDataEncryptionMetadata_dataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName = cmdletContext.DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName.Value;
            }
            if (requestDataEncryptionMetadata_dataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName != null)
            {
                request.DataEncryptionMetadata.AllowJoinsOnColumnsWithDifferentNames = requestDataEncryptionMetadata_dataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName.Value;
                requestDataEncryptionMetadataIsNull = false;
            }
            System.Boolean? requestDataEncryptionMetadata_dataEncryptionMetadata_PreserveNull = null;
            if (cmdletContext.DataEncryptionMetadata_PreserveNull != null)
            {
                requestDataEncryptionMetadata_dataEncryptionMetadata_PreserveNull = cmdletContext.DataEncryptionMetadata_PreserveNull.Value;
            }
            if (requestDataEncryptionMetadata_dataEncryptionMetadata_PreserveNull != null)
            {
                request.DataEncryptionMetadata.PreserveNulls = requestDataEncryptionMetadata_dataEncryptionMetadata_PreserveNull.Value;
                requestDataEncryptionMetadataIsNull = false;
            }
             // determine if request.DataEncryptionMetadata should be set to null
            if (requestDataEncryptionMetadataIsNull)
            {
                request.DataEncryptionMetadata = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Member != null)
            {
                request.Members = cmdletContext.Member;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.QueryLogStatus != null)
            {
                request.QueryLogStatus = cmdletContext.QueryLogStatus;
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
        
        private Amazon.CleanRooms.Model.CreateCollaborationResponse CallAWSServiceOperation(IAmazonCleanRooms client, Amazon.CleanRooms.Model.CreateCollaborationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Clean Rooms Service", "CreateCollaboration");
            try
            {
                #if DESKTOP
                return client.CreateCollaboration(request);
                #elif CORECLR
                return client.CreateCollaborationAsync(request).GetAwaiter().GetResult();
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
            public System.String CreatorDisplayName { get; set; }
            public List<System.String> CreatorMemberAbility { get; set; }
            public System.Boolean? DataEncryptionMetadata_AllowCleartext { get; set; }
            public System.Boolean? DataEncryptionMetadata_AllowDuplicate { get; set; }
            public System.Boolean? DataEncryptionMetadata_AllowJoinsOnColumnsWithDifferentName { get; set; }
            public System.Boolean? DataEncryptionMetadata_PreserveNull { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.CleanRooms.Model.MemberSpecification> Member { get; set; }
            public System.String Name { get; set; }
            public Amazon.CleanRooms.CollaborationQueryLogStatus QueryLogStatus { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRooms.Model.CreateCollaborationResponse, NewCRSCollaborationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Collaboration;
        }
        
    }
}
