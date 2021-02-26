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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Creates the specified WorkSpace bundle. For more information about creating WorkSpace
    /// bundles, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/create-custom-bundle.html">
    /// Create a Custom WorkSpaces Image and Bundle</a>.
    /// </summary>
    [Cmdlet("New", "WKSWorkspaceBundle", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.WorkspaceBundle")]
    [AWSCmdlet("Calls the Amazon WorkSpaces CreateWorkspaceBundle API operation.", Operation = new[] {"CreateWorkspaceBundle"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.WorkspaceBundle or Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.WorkspaceBundle object.",
        "The service call response (type Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWKSWorkspaceBundleCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        #region Parameter BundleDescription
        /// <summary>
        /// <para>
        /// <para>The description of the bundle.</para>
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
        public System.String BundleDescription { get; set; }
        #endregion
        
        #region Parameter BundleName
        /// <summary>
        /// <para>
        /// <para>The name of the bundle.</para>
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
        public System.String BundleName { get; set; }
        #endregion
        
        #region Parameter RootStorage_Capacity
        /// <summary>
        /// <para>
        /// <para>The size of the root volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RootStorage_Capacity { get; set; }
        #endregion
        
        #region Parameter UserStorage_Capacity
        /// <summary>
        /// <para>
        /// <para>The size of the user volume.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserStorage_Capacity { get; set; }
        #endregion
        
        #region Parameter ImageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the image that is used to create the bundle.</para>
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
        public System.String ImageId { get; set; }
        #endregion
        
        #region Parameter ComputeType_Name
        /// <summary>
        /// <para>
        /// <para>The compute type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.Compute")]
        public Amazon.WorkSpaces.Compute ComputeType_Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the bundle.</para><note><para>To add tags at the same time that you're creating the bundle, you must create an IAM
        /// policy that grants your IAM user permissions to use <code>workspaces:CreateTags</code>.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpaces.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkspaceBundle'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkspaceBundle";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BundleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BundleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BundleName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BundleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WKSWorkspaceBundle (CreateWorkspaceBundle)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse, NewWKSWorkspaceBundleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BundleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BundleDescription = this.BundleDescription;
            #if MODULAR
            if (this.BundleDescription == null && ParameterWasBound(nameof(this.BundleDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter BundleDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BundleName = this.BundleName;
            #if MODULAR
            if (this.BundleName == null && ParameterWasBound(nameof(this.BundleName)))
            {
                WriteWarning("You are passing $null as a value for parameter BundleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeType_Name = this.ComputeType_Name;
            context.ImageId = this.ImageId;
            #if MODULAR
            if (this.ImageId == null && ParameterWasBound(nameof(this.ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RootStorage_Capacity = this.RootStorage_Capacity;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkSpaces.Model.Tag>(this.Tag);
            }
            context.UserStorage_Capacity = this.UserStorage_Capacity;
            
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
            var request = new Amazon.WorkSpaces.Model.CreateWorkspaceBundleRequest();
            
            if (cmdletContext.BundleDescription != null)
            {
                request.BundleDescription = cmdletContext.BundleDescription;
            }
            if (cmdletContext.BundleName != null)
            {
                request.BundleName = cmdletContext.BundleName;
            }
            
             // populate ComputeType
            var requestComputeTypeIsNull = true;
            request.ComputeType = new Amazon.WorkSpaces.Model.ComputeType();
            Amazon.WorkSpaces.Compute requestComputeType_computeType_Name = null;
            if (cmdletContext.ComputeType_Name != null)
            {
                requestComputeType_computeType_Name = cmdletContext.ComputeType_Name;
            }
            if (requestComputeType_computeType_Name != null)
            {
                request.ComputeType.Name = requestComputeType_computeType_Name;
                requestComputeTypeIsNull = false;
            }
             // determine if request.ComputeType should be set to null
            if (requestComputeTypeIsNull)
            {
                request.ComputeType = null;
            }
            if (cmdletContext.ImageId != null)
            {
                request.ImageId = cmdletContext.ImageId;
            }
            
             // populate RootStorage
            var requestRootStorageIsNull = true;
            request.RootStorage = new Amazon.WorkSpaces.Model.RootStorage();
            System.String requestRootStorage_rootStorage_Capacity = null;
            if (cmdletContext.RootStorage_Capacity != null)
            {
                requestRootStorage_rootStorage_Capacity = cmdletContext.RootStorage_Capacity;
            }
            if (requestRootStorage_rootStorage_Capacity != null)
            {
                request.RootStorage.Capacity = requestRootStorage_rootStorage_Capacity;
                requestRootStorageIsNull = false;
            }
             // determine if request.RootStorage should be set to null
            if (requestRootStorageIsNull)
            {
                request.RootStorage = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate UserStorage
            var requestUserStorageIsNull = true;
            request.UserStorage = new Amazon.WorkSpaces.Model.UserStorage();
            System.String requestUserStorage_userStorage_Capacity = null;
            if (cmdletContext.UserStorage_Capacity != null)
            {
                requestUserStorage_userStorage_Capacity = cmdletContext.UserStorage_Capacity;
            }
            if (requestUserStorage_userStorage_Capacity != null)
            {
                request.UserStorage.Capacity = requestUserStorage_userStorage_Capacity;
                requestUserStorageIsNull = false;
            }
             // determine if request.UserStorage should be set to null
            if (requestUserStorageIsNull)
            {
                request.UserStorage = null;
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
        
        private Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.CreateWorkspaceBundleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "CreateWorkspaceBundle");
            try
            {
                #if DESKTOP
                return client.CreateWorkspaceBundle(request);
                #elif CORECLR
                return client.CreateWorkspaceBundleAsync(request).GetAwaiter().GetResult();
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
            public System.String BundleDescription { get; set; }
            public System.String BundleName { get; set; }
            public Amazon.WorkSpaces.Compute ComputeType_Name { get; set; }
            public System.String ImageId { get; set; }
            public System.String RootStorage_Capacity { get; set; }
            public List<Amazon.WorkSpaces.Model.Tag> Tag { get; set; }
            public System.String UserStorage_Capacity { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.CreateWorkspaceBundleResponse, NewWKSWorkspaceBundleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkspaceBundle;
        }
        
    }
}
