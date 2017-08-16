/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a <a>TypedLinkFacet</a>. For more information, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/objectsandlinks.html#typedlink">Typed
    /// link</a>.
    /// </summary>
    [Cmdlet("New", "CDIRTypedLinkFacet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the CreateTypedLinkFacet operation against AWS Cloud Directory.", Operation = new[] {"CreateTypedLinkFacet"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the SchemaArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudDirectory.Model.CreateTypedLinkFacetResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDIRTypedLinkFacetCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter Facet_Attribute
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs associated with the typed link. Typed link attributes are
        /// used when you have data values that are related to the link itself, and not to one
        /// of the two objects being linked. Identity attributes also serve to distinguish the
        /// link from others of the same type between the same objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.String[] Facet_IdentityAttributeOrder { get; set; }
        #endregion
        
        #region Parameter Facet_Name
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Facet_Name { get; set; }
        #endregion
        
        #region Parameter SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SchemaArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the SchemaArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SchemaArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDIRTypedLinkFacet (CreateTypedLinkFacet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Facet_Attribute != null)
            {
                context.Facet_Attributes = new List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition>(this.Facet_Attribute);
            }
            if (this.Facet_IdentityAttributeOrder != null)
            {
                context.Facet_IdentityAttributeOrder = new List<System.String>(this.Facet_IdentityAttributeOrder);
            }
            context.Facet_Name = this.Facet_Name;
            context.SchemaArn = this.SchemaArn;
            
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
            bool requestFacetIsNull = true;
            request.Facet = new Amazon.CloudDirectory.Model.TypedLinkFacet();
            List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition> requestFacet_facet_Attribute = null;
            if (cmdletContext.Facet_Attributes != null)
            {
                requestFacet_facet_Attribute = cmdletContext.Facet_Attributes;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.SchemaArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "CreateTypedLinkFacet");
            try
            {
                #if DESKTOP
                return client.CreateTypedLinkFacet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateTypedLinkFacetAsync(request);
                return task.Result;
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
            public List<Amazon.CloudDirectory.Model.TypedLinkAttributeDefinition> Facet_Attributes { get; set; }
            public List<System.String> Facet_IdentityAttributeOrder { get; set; }
            public System.String Facet_Name { get; set; }
            public System.String SchemaArn { get; set; }
        }
        
    }
}
