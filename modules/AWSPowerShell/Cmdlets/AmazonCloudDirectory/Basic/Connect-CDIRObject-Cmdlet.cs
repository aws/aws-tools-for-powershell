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
    /// Attaches an existing object to another object. An object can be accessed in two ways:
    /// 
    ///  <ol><li><para>
    /// Using the path
    /// </para></li><li><para>
    /// Using <code>ObjectIdentifier</code></para></li></ol>
    /// </summary>
    [Cmdlet("Connect", "CDIRObject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cloud Directory AttachObject API operation.", Operation = new[] {"AttachObject"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudDirectory.Model.AttachObjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConnectCDIRObjectCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) that is associated with the <a>Directory</a> where both
        /// objects reside. For more information, see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter LinkName
        /// <summary>
        /// <para>
        /// <para>The link name with which the child object is attached to the parent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LinkName { get; set; }
        #endregion
        
        #region Parameter ChildReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_access_objects.html">Access
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChildReference_Selector { get; set; }
        #endregion
        
        #region Parameter ParentReference_Selector
        /// <summary>
        /// <para>
        /// <para>A path selector supports easy selection of an object by the parent/child links leading
        /// to it from the directory root. Use the link names from each parent/child link to construct
        /// the path. Path selectors start with a slash (/) and link names are separated by slashes.
        /// For more information about paths, see <a href="https://docs.aws.amazon.com/clouddirectory/latest/developerguide/directory_objects_access_objects.html">Access
        /// Objects</a>. You can identify an object in one of the following ways:</para><ul><li><para><i>$ObjectIdentifier</i> - An object identifier is an opaque string provided by Amazon
        /// Cloud Directory. When creating objects, the system will provide you with the identifier
        /// of the created object. An object’s identifier is immutable and no two objects will
        /// ever share the same object identifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ParentReference_Selector { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-CDIRObject (AttachObject)"))
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
            
            context.ChildReference_Selector = this.ChildReference_Selector;
            context.DirectoryArn = this.DirectoryArn;
            context.LinkName = this.LinkName;
            context.ParentReference_Selector = this.ParentReference_Selector;
            
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
            var request = new Amazon.CloudDirectory.Model.AttachObjectRequest();
            
            
             // populate ChildReference
            bool requestChildReferenceIsNull = true;
            request.ChildReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestChildReference_childReference_Selector = null;
            if (cmdletContext.ChildReference_Selector != null)
            {
                requestChildReference_childReference_Selector = cmdletContext.ChildReference_Selector;
            }
            if (requestChildReference_childReference_Selector != null)
            {
                request.ChildReference.Selector = requestChildReference_childReference_Selector;
                requestChildReferenceIsNull = false;
            }
             // determine if request.ChildReference should be set to null
            if (requestChildReferenceIsNull)
            {
                request.ChildReference = null;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.LinkName != null)
            {
                request.LinkName = cmdletContext.LinkName;
            }
            
             // populate ParentReference
            bool requestParentReferenceIsNull = true;
            request.ParentReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestParentReference_parentReference_Selector = null;
            if (cmdletContext.ParentReference_Selector != null)
            {
                requestParentReference_parentReference_Selector = cmdletContext.ParentReference_Selector;
            }
            if (requestParentReference_parentReference_Selector != null)
            {
                request.ParentReference.Selector = requestParentReference_parentReference_Selector;
                requestParentReferenceIsNull = false;
            }
             // determine if request.ParentReference should be set to null
            if (requestParentReferenceIsNull)
            {
                request.ParentReference = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AttachedObjectIdentifier;
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
        
        private Amazon.CloudDirectory.Model.AttachObjectResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.AttachObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "AttachObject");
            try
            {
                #if DESKTOP
                return client.AttachObject(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AttachObjectAsync(request);
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
            public System.String ChildReference_Selector { get; set; }
            public System.String DirectoryArn { get; set; }
            public System.String LinkName { get; set; }
            public System.String ParentReference_Selector { get; set; }
        }
        
    }
}
