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
    /// Creates an index object. See <a href="http://docs.aws.amazon.com/directoryservice/latest/admin-guide/cd_indexing.html">Indexing</a>
    /// for more information.
    /// </summary>
    [Cmdlet("New", "CDIRIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateIndex operation against AWS Cloud Directory.", Operation = new[] {"CreateIndex"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudDirectory.Model.CreateIndexResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCDIRIndexCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the directory where the index should be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter IsUnique
        /// <summary>
        /// <para>
        /// <para>Indicates whether objects with the same indexed attribute value can be added to the
        /// index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IsUnique { get; set; }
        #endregion
        
        #region Parameter LinkName
        /// <summary>
        /// <para>
        /// <para>The name of the link between the parent object and the index object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LinkName { get; set; }
        #endregion
        
        #region Parameter OrderedIndexedAttributeList
        /// <summary>
        /// <para>
        /// <para>Specifies the Attributes that should be indexed on. Currently only a single attribute
        /// is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CloudDirectory.Model.AttributeKey[] OrderedIndexedAttributeList { get; set; }
        #endregion
        
        #region Parameter ParentReference_Selector
        /// <summary>
        /// <para>
        /// <para>Allows you to specify an object. You can identify an object in one of the following
        /// ways:</para><ul><li><para><i>$ObjectIdentifier</i> - Identifies the object by <code>ObjectIdentifier</code></para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CDIRIndex (CreateIndex)"))
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
            if (ParameterWasBound("IsUnique"))
                context.IsUnique = this.IsUnique;
            context.LinkName = this.LinkName;
            if (this.OrderedIndexedAttributeList != null)
            {
                context.OrderedIndexedAttributeList = new List<Amazon.CloudDirectory.Model.AttributeKey>(this.OrderedIndexedAttributeList);
            }
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
            var request = new Amazon.CloudDirectory.Model.CreateIndexRequest();
            
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.IsUnique != null)
            {
                request.IsUnique = cmdletContext.IsUnique.Value;
            }
            if (cmdletContext.LinkName != null)
            {
                request.LinkName = cmdletContext.LinkName;
            }
            if (cmdletContext.OrderedIndexedAttributeList != null)
            {
                request.OrderedIndexedAttributeList = cmdletContext.OrderedIndexedAttributeList;
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
                object pipelineOutput = response.ObjectIdentifier;
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
        
        private Amazon.CloudDirectory.Model.CreateIndexResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.CreateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cloud Directory", "CreateIndex");
            #if DESKTOP
            return client.CreateIndex(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateIndexAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DirectoryArn { get; set; }
            public System.Boolean? IsUnique { get; set; }
            public System.String LinkName { get; set; }
            public List<Amazon.CloudDirectory.Model.AttributeKey> OrderedIndexedAttributeList { get; set; }
            public System.String ParentReference_Selector { get; set; }
        }
        
    }
}
