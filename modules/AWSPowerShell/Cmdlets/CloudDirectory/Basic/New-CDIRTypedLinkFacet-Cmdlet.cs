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
using Amazon.CloudDirectory;
using Amazon.CloudDirectory.Model;

namespace Amazon.PowerShell.Cmdlets.CDIR
{
    /// <summary>
    /// Creates a <a>TypedLinkFacet</a>. For more information, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_links.html#directory_objects_links_typedlink">Typed
    /// Links</a>.
    /// </summary>
    [Cmdlet("New", "CDIRTypedLinkFacet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cloud Directory CreateTypedLinkFacet API operation.", Operation = new[] {"CreateTypedLinkFacet"}, SelectReturnType = typeof(Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse))]
    [AWSCmdletOutput("None or Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewCDIRTypedLinkFacetCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Facet_Attribute
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs associated with the typed link. Typed link attributes are
        /// used when you have data values that are related to the link itself, and not to one
        /// of the two objects being linked. Identity attributes also serve to distinguish the
        /// link from others of the same type between the same objects.</para>
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
        [Alias("Facet_Attributes")]
        public Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition[] Facet_Attribute { get; set; }
        #endregion
        
        #region Parameter Facet_IdentityAttributeOrder
        /// <summary>
        /// <para>
        /// <para>The set of attributes that distinguish links made from this facet from each other,
        /// in the order of significance. Listing typed links can filter on the values of these
        /// attributes. See <a>ListOutgoingTypedLinks</a> and <a>ListIncomingTypedLinks</a> for
        /// details.</para>
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
        public System.String[] Facet_IdentityAttributeOrder { get; set; }
        #endregion
        
        #region Parameter Facet_Name
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
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
        public System.String Facet_Name { get; set; }
        #endregion
        
        #region Parameter SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
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
        public System.String SchemaArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SchemaArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDIRTypedLinkFacet (CreateTypedLinkFacet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse, NewCDIRTypedLinkFacetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Facet_Attribute != null)
            {
                context.Facet_Attribute = new List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition>(this.Facet_Attribute);
            }
            #if MODULAR
            if (this.Facet_Attribute == null && ParameterWasBound(nameof(this.Facet_Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter Facet_Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Facet_IdentityAttributeOrder != null)
            {
                context.Facet_IdentityAttributeOrder = new List<System.String>(this.Facet_IdentityAttributeOrder);
            }
            #if MODULAR
            if (this.Facet_IdentityAttributeOrder == null && ParameterWasBound(nameof(this.Facet_IdentityAttributeOrder)))
            {
                WriteWarning("You are passing $null as a value for parameter Facet_IdentityAttributeOrder which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Facet_Name = this.Facet_Name;
            #if MODULAR
            if (this.Facet_Name == null && ParameterWasBound(nameof(this.Facet_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Facet_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaArn = this.SchemaArn;
            #if MODULAR
            if (this.SchemaArn == null && ParameterWasBound(nameof(this.SchemaArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SchemaArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudDirectory.Model.CreateTypedLinkFacetRequest();
            
            
             // populate Facet
            var requestFacetIsNull = true;
            request.Facet = new Amazon.CloudDirectory.Model.TypedLinkFacet();
            List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition> requestFacet_facet_Attribute = null;
            if (cmdletContext.Facet_Attribute != null)
            {
                requestFacet_facet_Attribute = cmdletContext.Facet_Attribute;
            }
            if (requestFacet_facet_Attribute != null)
            {
                request.Facet.Attributes = requestFacet_facet_Attribute;
                requestFacetIsNull = false;
            }
            List<System.String> requestFacet_facet_IdentityAttributeOrder = null;
            if (cmdletContext.Facet_IdentityAttributeOrder != null)
            {
                requestFacet_facet_IdentityAttributeOrder = cmdletContext.Facet_IdentityAttributeOrder;
            }
            if (requestFacet_facet_IdentityAttributeOrder != null)
            {
                request.Facet.IdentityAttributeOrder = requestFacet_facet_IdentityAttributeOrder;
                requestFacetIsNull = false;
            }
            System.String requestFacet_facet_Name = null;
            if (cmdletContext.Facet_Name != null)
            {
                requestFacet_facet_Name = cmdletContext.Facet_Name;
            }
            if (requestFacet_facet_Name != null)
            {
                request.Facet.Name = requestFacet_facet_Name;
                requestFacetIsNull = false;
            }
             // determine if request.Facet should be set to null
            if (requestFacetIsNull)
            {
                request.Facet = null;
            }
            if (cmdletContext.SchemaArn != null)
            {
                request.SchemaArn = cmdletContext.SchemaArn;
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
        
        private Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.CreateTypedLinkFacetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cloud Directory", "CreateTypedLinkFacet");
            try
            {
                #if DESKTOP
                return client.CreateTypedLinkFacet(request);
                #elif CORECLR
                return client.CreateTypedLinkFacetAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition> Facet_Attribute { get; set; }
            public List<System.String> Facet_IdentityAttributeOrder { get; set; }
            public System.String Facet_Name { get; set; }
            public System.String SchemaArn { get; set; }
            public System.Func<Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse, NewCDIRTypedLinkFacetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
