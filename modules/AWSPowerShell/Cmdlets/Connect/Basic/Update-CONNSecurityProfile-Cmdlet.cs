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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates a security profile.
    /// 
    ///  
    /// <para>
    /// For information about security profiles, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/connect-security-profiles.html">Security
    /// Profiles</a> in the <i>Amazon Connect Administrator Guide</i>. For a mapping of the
    /// API name and user interface name of the security profile permissions, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-profile-list.html">List
    /// of security profile permissions</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNSecurityProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateSecurityProfile API operation.", Operation = new[] {"UpdateSecurityProfile"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateSecurityProfileResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateSecurityProfileResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateSecurityProfileResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCONNSecurityProfileCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowedAccessControlHierarchyGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier of the hierarchy group that a security profile uses to restrict access
        /// to resources in Amazon Connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AllowedAccessControlHierarchyGroupId { get; set; }
        #endregion
        
        #region Parameter AllowedAccessControlTag
        /// <summary>
        /// <para>
        /// <para>The list of tags that a security profile uses to restrict access to resources in Amazon
        /// Connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedAccessControlTags")]
        public System.Collections.Hashtable AllowedAccessControlTag { get; set; }
        #endregion
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>A list of the third-party application's metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public Amazon.Connect.Model.Application[] Application { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the security profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HierarchyRestrictedResource
        /// <summary>
        /// <para>
        /// <para>The list of resources that a security profile applies hierarchy restrictions to in
        /// Amazon Connect. Following are acceptable ResourceNames: <c>User</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HierarchyRestrictedResources")]
        public System.String[] HierarchyRestrictedResource { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Permission
        /// <summary>
        /// <para>
        /// <para>The permissions granted to a security profile. For a list of valid permissions, see
        /// <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-profile-list.html">List
        /// of security profile permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions")]
        public System.String[] Permission { get; set; }
        #endregion
        
        #region Parameter SecurityProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier for the security profle.</para>
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
        public System.String SecurityProfileId { get; set; }
        #endregion
        
        #region Parameter TagRestrictedResource
        /// <summary>
        /// <para>
        /// <para>The list of resources that a security profile applies tag restrictions to in Amazon
        /// Connect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagRestrictedResources")]
        public System.String[] TagRestrictedResource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateSecurityProfileResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecurityProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecurityProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecurityProfileId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecurityProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNSecurityProfile (UpdateSecurityProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateSecurityProfileResponse, UpdateCONNSecurityProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecurityProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowedAccessControlHierarchyGroupId = this.AllowedAccessControlHierarchyGroupId;
            if (this.AllowedAccessControlTag != null)
            {
                context.AllowedAccessControlTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AllowedAccessControlTag.Keys)
                {
                    context.AllowedAccessControlTag.Add((String)hashKey, (System.String)(this.AllowedAccessControlTag[hashKey]));
                }
            }
            if (this.Application != null)
            {
                context.Application = new List<Amazon.Connect.Model.Application>(this.Application);
            }
            context.Description = this.Description;
            if (this.HierarchyRestrictedResource != null)
            {
                context.HierarchyRestrictedResource = new List<System.String>(this.HierarchyRestrictedResource);
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permission != null)
            {
                context.Permission = new List<System.String>(this.Permission);
            }
            context.SecurityProfileId = this.SecurityProfileId;
            #if MODULAR
            if (this.SecurityProfileId == null && ParameterWasBound(nameof(this.SecurityProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagRestrictedResource != null)
            {
                context.TagRestrictedResource = new List<System.String>(this.TagRestrictedResource);
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
            var request = new Amazon.Connect.Model.UpdateSecurityProfileRequest();
            
            if (cmdletContext.AllowedAccessControlHierarchyGroupId != null)
            {
                request.AllowedAccessControlHierarchyGroupId = cmdletContext.AllowedAccessControlHierarchyGroupId;
            }
            if (cmdletContext.AllowedAccessControlTag != null)
            {
                request.AllowedAccessControlTags = cmdletContext.AllowedAccessControlTag;
            }
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HierarchyRestrictedResource != null)
            {
                request.HierarchyRestrictedResources = cmdletContext.HierarchyRestrictedResource;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Permission != null)
            {
                request.Permissions = cmdletContext.Permission;
            }
            if (cmdletContext.SecurityProfileId != null)
            {
                request.SecurityProfileId = cmdletContext.SecurityProfileId;
            }
            if (cmdletContext.TagRestrictedResource != null)
            {
                request.TagRestrictedResources = cmdletContext.TagRestrictedResource;
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
        
        private Amazon.Connect.Model.UpdateSecurityProfileResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateSecurityProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateSecurityProfile");
            try
            {
                #if DESKTOP
                return client.UpdateSecurityProfile(request);
                #elif CORECLR
                return client.UpdateSecurityProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String AllowedAccessControlHierarchyGroupId { get; set; }
            public Dictionary<System.String, System.String> AllowedAccessControlTag { get; set; }
            public List<Amazon.Connect.Model.Application> Application { get; set; }
            public System.String Description { get; set; }
            public List<System.String> HierarchyRestrictedResource { get; set; }
            public System.String InstanceId { get; set; }
            public List<System.String> Permission { get; set; }
            public System.String SecurityProfileId { get; set; }
            public List<System.String> TagRestrictedResource { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateSecurityProfileResponse, UpdateCONNSecurityProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
