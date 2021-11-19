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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// For Redis engine version 6.0 onwards: Creates a Redis user group. For more information,
    /// see <a href="http://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/Clusters.RBAC.html">Using
    /// Role Based Access Control (RBAC)</a>
    /// </summary>
    [Cmdlet("New", "ECUserGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.CreateUserGroupResponse")]
    [AWSCmdlet("Calls the Amazon ElastiCache CreateUserGroup API operation.", Operation = new[] {"CreateUserGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.CreateUserGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CreateUserGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CreateUserGroupResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewECUserGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The current supported value is Redis. </para>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be added to this resource. A tag is a key-value pair. A tag key
        /// must be accompanied by a tag value, although null is accepted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElastiCache.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter UserGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the user group.</para>
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
        public System.String UserGroupId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The list of user IDs that belong to the user group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserIds")]
        public System.String[] UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.CreateUserGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.CreateUserGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ECUserGroup (CreateUserGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.CreateUserGroupResponse, NewECUserGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElastiCache.Model.Tag>(this.Tag);
            }
            context.UserGroupId = this.UserGroupId;
            #if MODULAR
            if (this.UserGroupId == null && ParameterWasBound(nameof(this.UserGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserId != null)
            {
                context.UserId = new List<System.String>(this.UserId);
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
            var request = new Amazon.ElastiCache.Model.CreateUserGroupRequest();
            
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserGroupId != null)
            {
                request.UserGroupId = cmdletContext.UserGroupId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserIds = cmdletContext.UserId;
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
        
        private Amazon.ElastiCache.Model.CreateUserGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.CreateUserGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "CreateUserGroup");
            try
            {
                #if DESKTOP
                return client.CreateUserGroup(request);
                #elif CORECLR
                return client.CreateUserGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Engine { get; set; }
            public List<Amazon.ElastiCache.Model.Tag> Tag { get; set; }
            public System.String UserGroupId { get; set; }
            public List<System.String> UserId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.CreateUserGroupResponse, NewECUserGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
