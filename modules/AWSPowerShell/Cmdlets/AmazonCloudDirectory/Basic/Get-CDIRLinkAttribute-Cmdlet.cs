/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Retrieves attributes that are associated with a typed link.
    /// </summary>
    [Cmdlet("Get", "CDIRLinkAttribute")]
    [OutputType("Amazon.CloudDirectory.Model.AttributeKeyAndValue")]
    [AWSCmdlet("Calls the AWS Cloud Directory GetLinkAttributes API operation.", Operation = new[] {"GetLinkAttributes"})]
    [AWSCmdletOutput("Amazon.CloudDirectory.Model.AttributeKeyAndValue",
        "This cmdlet returns a collection of AttributeKeyAndValue objects.",
        "The service call response (type Amazon.CloudDirectory.Model.GetLinkAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDIRLinkAttributeCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>A list of attribute names whose values will be retrieved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AttributeNames")]
        public System.String[] AttributeName { get; set; }
        #endregion
        
        #region Parameter ConsistencyLevel
        /// <summary>
        /// <para>
        /// <para>The consistency level at which to retrieve the attributes on a typed link.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudDirectory.ConsistencyLevel")]
        public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the Directory where the typed
        /// link resides. For more information, see <a>arns</a> or <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/objectsandlinks.html#typedlink">Typed
        /// link</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter TypedLinkSpecifier_IdentityAttributeValue
        /// <summary>
        /// <para>
        /// <para>Identifies the attribute value to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_IdentityAttributeValues")]
        public Amazon.CloudDirectory.Model.AttributeNameAndValue[] TypedLinkSpecifier_IdentityAttributeValue { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_SchemaArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that is associated with the schema. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_TypedLinkFacet_SchemaArn")]
        public System.String TypedLinkFacet_SchemaArn { get; set; }
        #endregion
        
        #region Parameter SourceObjectReference_Selector
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
        [Alias("TypedLinkSpecifier_SourceObjectReference_Selector")]
        public System.String SourceObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter TargetObjectReference_Selector
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
        [Alias("TypedLinkSpecifier_TargetObjectReference_Selector")]
        public System.String TargetObjectReference_Selector { get; set; }
        #endregion
        
        #region Parameter TypedLinkFacet_TypedLinkName
        /// <summary>
        /// <para>
        /// <para>The unique name of the typed link facet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TypedLinkSpecifier_TypedLinkFacet_TypedLinkName")]
        public System.String TypedLinkFacet_TypedLinkName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AttributeName != null)
            {
                context.AttributeNames = new List<System.String>(this.AttributeName);
            }
            context.ConsistencyLevel = this.ConsistencyLevel;
            context.DirectoryArn = this.DirectoryArn;
            if (this.TypedLinkSpecifier_IdentityAttributeValue != null)
            {
                context.TypedLinkSpecifier_IdentityAttributeValues = new List<Amazon.CloudDirectory.Model.AttributeNameAndValue>(this.TypedLinkSpecifier_IdentityAttributeValue);
            }
            context.TypedLinkSpecifier_SourceObjectReference_Selector = this.SourceObjectReference_Selector;
            context.TypedLinkSpecifier_TargetObjectReference_Selector = this.TargetObjectReference_Selector;
            context.TypedLinkSpecifier_TypedLinkFacet_SchemaArn = this.TypedLinkFacet_SchemaArn;
            context.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName = this.TypedLinkFacet_TypedLinkName;
            
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
            var request = new Amazon.CloudDirectory.Model.GetLinkAttributesRequest();
            
            if (cmdletContext.AttributeNames != null)
            {
                request.AttributeNames = cmdletContext.AttributeNames;
            }
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate TypedLinkSpecifier
            bool requestTypedLinkSpecifierIsNull = true;
            request.TypedLinkSpecifier = new Amazon.CloudDirectory.Model.TypedLinkSpecifier();
            List<Amazon.CloudDirectory.Model.AttributeNameAndValue> requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue = null;
            if (cmdletContext.TypedLinkSpecifier_IdentityAttributeValues != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue = cmdletContext.TypedLinkSpecifier_IdentityAttributeValues;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue != null)
            {
                request.TypedLinkSpecifier.IdentityAttributeValues = requestTypedLinkSpecifier_typedLinkSpecifier_IdentityAttributeValue;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.ObjectReference requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = null;
            
             // populate SourceObjectReference
            bool requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector = null;
            if (cmdletContext.TypedLinkSpecifier_SourceObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector = cmdletContext.TypedLinkSpecifier_SourceObjectReference_Selector;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference.Selector = requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference_sourceObjectReference_Selector;
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReferenceIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference != null)
            {
                request.TypedLinkSpecifier.SourceObjectReference = requestTypedLinkSpecifier_typedLinkSpecifier_SourceObjectReference;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.ObjectReference requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = null;
            
             // populate TargetObjectReference
            bool requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector = null;
            if (cmdletContext.TypedLinkSpecifier_TargetObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector = cmdletContext.TypedLinkSpecifier_TargetObjectReference_Selector;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference.Selector = requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference_targetObjectReference_Selector;
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReferenceIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference != null)
            {
                request.TypedLinkSpecifier.TargetObjectReference = requestTypedLinkSpecifier_typedLinkSpecifier_TargetObjectReference;
                requestTypedLinkSpecifierIsNull = false;
            }
            Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = null;
            
             // populate TypedLinkFacet
            bool requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = true;
            requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = new Amazon.CloudDirectory.Model.TypedLinkSchemaAndFacetName();
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn = null;
            if (cmdletContext.TypedLinkSpecifier_TypedLinkFacet_SchemaArn != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn = cmdletContext.TypedLinkSpecifier_TypedLinkFacet_SchemaArn;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet.SchemaArn = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_SchemaArn;
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = false;
            }
            System.String requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName = null;
            if (cmdletContext.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName = cmdletContext.TypedLinkSpecifier_TypedLinkFacet_TypedLinkName;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName != null)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet.TypedLinkName = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet_typedLinkFacet_TypedLinkName;
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull = false;
            }
             // determine if requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet should be set to null
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacetIsNull)
            {
                requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet = null;
            }
            if (requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet != null)
            {
                request.TypedLinkSpecifier.TypedLinkFacet = requestTypedLinkSpecifier_typedLinkSpecifier_TypedLinkFacet;
                requestTypedLinkSpecifierIsNull = false;
            }
             // determine if request.TypedLinkSpecifier should be set to null
            if (requestTypedLinkSpecifierIsNull)
            {
                request.TypedLinkSpecifier = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Attributes;
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
        
        private Amazon.CloudDirectory.Model.GetLinkAttributesResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.GetLinkAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "GetLinkAttributes");
            try
            {
                #if DESKTOP
                return client.GetLinkAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetLinkAttributesAsync(request);
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
            public List<System.String> AttributeNames { get; set; }
            public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
            public System.String DirectoryArn { get; set; }
            public List<Amazon.CloudDirectory.Model.AttributeNameAndValue> TypedLinkSpecifier_IdentityAttributeValues { get; set; }
            public System.String TypedLinkSpecifier_SourceObjectReference_Selector { get; set; }
            public System.String TypedLinkSpecifier_TargetObjectReference_Selector { get; set; }
            public System.String TypedLinkSpecifier_TypedLinkFacet_SchemaArn { get; set; }
            public System.String TypedLinkSpecifier_TypedLinkFacet_TypedLinkName { get; set; }
        }
        
    }
}
