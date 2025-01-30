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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Modifies the set of security groups in effect for a mount target.
    /// 
    ///  
    /// <para>
    /// When you create a mount target, Amazon EFS also creates a new network interface. For
    /// more information, see <a>CreateMountTarget</a>. This operation replaces the security
    /// groups in effect for the network interface associated with a mount target, with the
    /// <c>SecurityGroups</c> provided in the request. This operation requires that the network
    /// interface of the mount target has been created and the lifecycle state of the mount
    /// target is not <c>deleted</c>. 
    /// </para><para>
    /// The operation requires permissions for the following actions:
    /// </para><ul><li><para><c>elasticfilesystem:ModifyMountTargetSecurityGroups</c> action on the mount target's
    /// file system. 
    /// </para></li><li><para><c>ec2:ModifyNetworkInterfaceAttribute</c> action on the mount target's network interface.
    /// 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Edit", "EFSMountTargetSecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic File System ModifyMountTargetSecurityGroups API operation.", Operation = new[] {"ModifyMountTargetSecurityGroups"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditEFSMountTargetSecurityGroupCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MountTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the mount target whose security groups you want to modify.</para>
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
        public System.String MountTargetId { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>An array of up to five VPC security group IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecurityGroup parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecurityGroup' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecurityGroup' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MountTargetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EFSMountTargetSecurityGroup (ModifyMountTargetSecurityGroups)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse, EditEFSMountTargetSecurityGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecurityGroup;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MountTargetId = this.MountTargetId;
            #if MODULAR
            if (this.MountTargetId == null && ParameterWasBound(nameof(this.MountTargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter MountTargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
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
            var request = new Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsRequest();
            
            if (cmdletContext.MountTargetId != null)
            {
                request.MountTargetId = cmdletContext.MountTargetId;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
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
        
        private Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "ModifyMountTargetSecurityGroups");
            try
            {
                #if DESKTOP
                return client.ModifyMountTargetSecurityGroups(request);
                #elif CORECLR
                return client.ModifyMountTargetSecurityGroupsAsync(request).GetAwaiter().GetResult();
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
            public System.String MountTargetId { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.ModifyMountTargetSecurityGroupsResponse, EditEFSMountTargetSecurityGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
