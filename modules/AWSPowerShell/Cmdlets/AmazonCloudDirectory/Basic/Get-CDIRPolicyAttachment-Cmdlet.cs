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
    /// Returns all of the ObjectIdentifiers to which a given policy is attached.
    /// </summary>
    [Cmdlet("Get", "CDIRPolicyAttachment")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListPolicyAttachments operation against AWS Cloud Directory.", Operation = new[] {"ListPolicyAttachments"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.CloudDirectory.Model.ListPolicyAttachmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetCDIRPolicyAttachmentCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter ConsistencyLevel
        /// <summary>
        /// <para>
        /// <para>Represents the manner and timing in which the successful write or update of an object
        /// is reflected in a subsequent read operation of that same object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CloudDirectory.ConsistencyLevel")]
        public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
        #endregion
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>ARN associated with the <a>Directory</a> where objects reside. For more information,
        /// see <a>arns</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter PolicyReference_Selector
        /// <summary>
        /// <para>
        /// <para>Allows you to specify an object. You can identify an object in one of the following
        /// ways:</para><ul><li><para><i>$ObjectIdentifier</i> - Identifies the object by ObjectIdentifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PolicyReference_Selector { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of items to be retrieved in a single call. This is an approximate number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Token used for pagination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
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
            
            context.ConsistencyLevel = this.ConsistencyLevel;
            context.DirectoryArn = this.DirectoryArn;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PolicyReference_Selector = this.PolicyReference_Selector;
            
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
            var request = new Amazon.CloudDirectory.Model.ListPolicyAttachmentsRequest();
            
            if (cmdletContext.ConsistencyLevel != null)
            {
                request.ConsistencyLevel = cmdletContext.ConsistencyLevel;
            }
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate PolicyReference
            bool requestPolicyReferenceIsNull = true;
            request.PolicyReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestPolicyReference_policyReference_Selector = null;
            if (cmdletContext.PolicyReference_Selector != null)
            {
                requestPolicyReference_policyReference_Selector = cmdletContext.PolicyReference_Selector;
            }
            if (requestPolicyReference_policyReference_Selector != null)
            {
                request.PolicyReference.Selector = requestPolicyReference_policyReference_Selector;
                requestPolicyReferenceIsNull = false;
            }
             // determine if request.PolicyReference should be set to null
            if (requestPolicyReferenceIsNull)
            {
                request.PolicyReference = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ObjectIdentifiers;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
        
        private static Amazon.CloudDirectory.Model.ListPolicyAttachmentsResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.ListPolicyAttachmentsRequest request)
        {
            #if DESKTOP
            return client.ListPolicyAttachments(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ListPolicyAttachmentsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Amazon.CloudDirectory.ConsistencyLevel ConsistencyLevel { get; set; }
            public System.String DirectoryArn { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String NextToken { get; set; }
            public System.String PolicyReference_Selector { get; set; }
        }
        
    }
}
