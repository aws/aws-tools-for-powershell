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
    /// Adds a new <a>Facet</a> to an object.
    /// </summary>
    [Cmdlet("Add", "CDIRFacetToObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Cloud Directory AddFacetToObject API operation.", Operation = new[] {"AddFacetToObject"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DirectoryArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CloudDirectory.Model.AddFacetToObjectResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddCDIRFacetToObjectCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the <a>Directory</a> where
        /// the object resides. For more information, see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter SchemaFacet_FacetName
        /// <summary>
        /// <para>
        /// <para>The name of the facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SchemaFacet_FacetName { get; set; }
        #endregion
        
        #region Parameter ObjectAttributeList
        /// <summary>
        /// <para>
        /// <para>Attributes on the facet that you are adding to the object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CloudDirectory.Model.AttributeKeyAndValue[] ObjectAttributeList { get; set; }
        #endregion
        
        #region Parameter SchemaFacet_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the schema that contains the facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SchemaFacet_SchemaArn { get; set; }
        #endregion
        
        #region Parameter ObjectReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/objectsandlinks.html#accessingobjects">Accessing
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DirectoryArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DirectoryArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CDIRFacetToObject (AddFacetToObject)"))
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
            
            context.DirectoryArn = this.DirectoryArn;
            if (this.ObjectAttributeList != null)
            {
                context.ObjectAttributeList = new List<Amazon.CloudDirectory.Model.AttributeKeyAndValue>(this.ObjectAttributeList);
            }
            context.ObjectReference_Selector = this.ObjectReference_Selector;
            context.SchemaFacet_FacetName = this.SchemaFacet_FacetName;
            context.SchemaFacet_SchemaArn = this.SchemaFacet_SchemaArn;
            
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
            var request = new Amazon.CloudDirectory.Model.AddFacetToObjectRequest();
            
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.ObjectAttributeList != null)
            {
                request.ObjectAttributeList = cmdletContext.ObjectAttributeList;
            }
            
             // populate ObjectReference
            bool requestObjectReferenceIsNull = true;
            request.ObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestObjectReference_objectReference_Selector = null;
            if (cmdletContext.ObjectReference_Selector != null)
            {
                requestObjectReference_objectReference_Selector = cmdletContext.ObjectReference_Selector;
            }
            if (requestObjectReference_objectReference_Selector != null)
            {
                request.ObjectReference.Selector = requestObjectReference_objectReference_Selector;
                requestObjectReferenceIsNull = false;
            }
             // determine if request.ObjectReference should be set to null
            if (requestObjectReferenceIsNull)
            {
                request.ObjectReference = null;
            }
            
             // populate SchemaFacet
            bool requestSchemaFacetIsNull = true;
            request.SchemaFacet = new Amazon.CloudDirectory.Model.SchemaFacet();
            System.String requestSchemaFacet_schemaFacet_FacetName = null;
            if (cmdletContext.SchemaFacet_FacetName != null)
            {
                requestSchemaFacet_schemaFacet_FacetName = cmdletContext.SchemaFacet_FacetName;
            }
            if (requestSchemaFacet_schemaFacet_FacetName != null)
            {
                request.SchemaFacet.FacetName = requestSchemaFacet_schemaFacet_FacetName;
                requestSchemaFacetIsNull = false;
            }
            System.String requestSchemaFacet_schemaFacet_SchemaArn = null;
            if (cmdletContext.SchemaFacet_SchemaArn != null)
            {
                requestSchemaFacet_schemaFacet_SchemaArn = cmdletContext.SchemaFacet_SchemaArn;
            }
            if (requestSchemaFacet_schemaFacet_SchemaArn != null)
            {
                request.SchemaFacet.SchemaArn = requestSchemaFacet_schemaFacet_SchemaArn;
                requestSchemaFacetIsNull = false;
            }
             // determine if request.SchemaFacet should be set to null
            if (requestSchemaFacetIsNull)
            {
                request.SchemaFacet = null;
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
                    pipelineOutput = this.DirectoryArn;
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
        
        private Amazon.CloudDirectory.Model.AddFacetToObjectResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.AddFacetToObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "AddFacetToObject");
            try
            {
                #if DESKTOP
                return client.AddFacetToObject(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddFacetToObjectAsync(request);
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
            public System.String DirectoryArn { get; set; }
            public List<Amazon.CloudDirectory.Model.AttributeKeyAndValue> ObjectAttributeList { get; set; }
            public System.String ObjectReference_Selector { get; set; }
            public System.String SchemaFacet_FacetName { get; set; }
            public System.String SchemaFacet_SchemaArn { get; set; }
        }
        
    }
}
