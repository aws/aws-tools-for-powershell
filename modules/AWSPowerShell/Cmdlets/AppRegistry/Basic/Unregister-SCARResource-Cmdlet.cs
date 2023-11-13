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
using Amazon.AppRegistry;
using Amazon.AppRegistry.Model;

namespace Amazon.PowerShell.Cmdlets.SCAR
{
    /// <summary>
    /// Disassociates a resource from application. Both the resource and the application
    /// can be specified either by ID or name. 
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    ///  You must have the following permissions to remove a resource that's been associated
    /// with an application using the <code>APPLY_APPLICATION_TAG</code> option for <a href="https://docs.aws.amazon.com/servicecatalog/latest/dg/API_app-registry_AssociateResource.html">AssociateResource</a>.
    /// 
    /// </para><ul><li><para><code>tag:GetResources</code></para></li><li><para><code>tag:UntagResources</code></para></li></ul><para>
    ///  You must also have the following permissions if you don't use the <code>AWSServiceCatalogAppRegistryFullAccess</code>
    /// policy. For more information, see <a href="https://docs.aws.amazon.com/servicecatalog/latest/arguide/full.html">AWSServiceCatalogAppRegistryFullAccess</a>
    /// in the AppRegistry Administrator Guide. 
    /// </para><ul><li><para><code>resource-groups:DisassociateResource</code></para></li><li><para><code>cloudformation:UpdateStack</code></para></li><li><para><code>cloudformation:DescribeStacks</code></para></li></ul><note><para>
    ///  In addition, you must have the tagging permission defined by the Amazon Web Services
    /// service that creates the resource. For more information, see <a href="https://docs.aws.amazon.com/resourcegroupstagging/latest/APIReference/API_UntTagResources.html">UntagResources</a>
    /// in the <i>Resource Groups Tagging API Reference</i>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Unregister", "SCARResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppRegistry.Model.DisassociateResourceResponse")]
    [AWSCmdlet("Calls the AWS Service Catalog App Registry DisassociateResource API operation.", Operation = new[] {"DisassociateResource"}, SelectReturnType = typeof(Amazon.AppRegistry.Model.DisassociateResourceResponse))]
    [AWSCmdletOutput("Amazon.AppRegistry.Model.DisassociateResourceResponse",
        "This cmdlet returns an Amazon.AppRegistry.Model.DisassociateResourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterSCARResourceCmdlet : AmazonAppRegistryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>The name or ID of the application.</para>
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
        public System.String Application { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The name or ID of the resource.</para>
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
        public System.String Resource { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the resource that is being disassociated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppRegistry.ResourceType")]
        public Amazon.AppRegistry.ResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppRegistry.Model.DisassociateResourceResponse).
        /// Specifying the name of a property of type Amazon.AppRegistry.Model.DisassociateResourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Application), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SCARResource (DisassociateResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppRegistry.Model.DisassociateResourceResponse, UnregisterSCARResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Application = this.Application;
            #if MODULAR
            if (this.Application == null && ParameterWasBound(nameof(this.Application)))
            {
                WriteWarning("You are passing $null as a value for parameter Application which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Resource = this.Resource;
            #if MODULAR
            if (this.Resource == null && ParameterWasBound(nameof(this.Resource)))
            {
                WriteWarning("You are passing $null as a value for parameter Resource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppRegistry.Model.DisassociateResourceRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Application = cmdletContext.Application;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resource = cmdletContext.Resource;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
        
        private Amazon.AppRegistry.Model.DisassociateResourceResponse CallAWSServiceOperation(IAmazonAppRegistry client, Amazon.AppRegistry.Model.DisassociateResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Catalog App Registry", "DisassociateResource");
            try
            {
                #if DESKTOP
                return client.DisassociateResource(request);
                #elif CORECLR
                return client.DisassociateResourceAsync(request).GetAwaiter().GetResult();
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
            public System.String Application { get; set; }
            public System.String Resource { get; set; }
            public Amazon.AppRegistry.ResourceType ResourceType { get; set; }
            public System.Func<Amazon.AppRegistry.Model.DisassociateResourceResponse, UnregisterSCARResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
