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
    /// Detaches the specified object from the specified index.
    /// </summary>
    [Cmdlet("Dismount", "CDIRObjectFromIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the DetachFromIndex operation against AWS Cloud Directory.", Operation = new[] {"DetachFromIndex"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudDirectory.Model.DetachFromIndexResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DismountCDIRObjectFromIndexCmdlet : AmazonCloudDirectoryClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the directory the index and object exist in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DirectoryArn { get; set; }
        #endregion
        
        #region Parameter IndexReference_Selector
        /// <summary>
        /// <para>
        /// <para>Allows you to specify an object. You can identify an object in one of the following
        /// ways:</para><ul><li><para><i>$ObjectIdentifier</i> - Identifies the object by ObjectIdentifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IndexReference_Selector { get; set; }
        #endregion
        
        #region Parameter TargetReference_Selector
        /// <summary>
        /// <para>
        /// <para>Allows you to specify an object. You can identify an object in one of the following
        /// ways:</para><ul><li><para><i>$ObjectIdentifier</i> - Identifies the object by ObjectIdentifier</para></li><li><para><i>/some/path</i> - Identifies the object based on path</para></li><li><para><i>#SomeBatchReference</i> - Identifies the object in a batch call</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetReference_Selector { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Dismount-CDIRObjectFromIndex (DetachFromIndex)"))
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
            context.IndexReference_Selector = this.IndexReference_Selector;
            context.TargetReference_Selector = this.TargetReference_Selector;
            
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
            var request = new Amazon.CloudDirectory.Model.DetachFromIndexRequest();
            
            if (cmdletContext.DirectoryArn != null)
            {
                request.DirectoryArn = cmdletContext.DirectoryArn;
            }
            
             // populate IndexReference
            bool requestIndexReferenceIsNull = true;
            request.IndexReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestIndexReference_indexReference_Selector = null;
            if (cmdletContext.IndexReference_Selector != null)
            {
                requestIndexReference_indexReference_Selector = cmdletContext.IndexReference_Selector;
            }
            if (requestIndexReference_indexReference_Selector != null)
            {
                request.IndexReference.Selector = requestIndexReference_indexReference_Selector;
                requestIndexReferenceIsNull = false;
            }
             // determine if request.IndexReference should be set to null
            if (requestIndexReferenceIsNull)
            {
                request.IndexReference = null;
            }
            
             // populate TargetReference
            bool requestTargetReferenceIsNull = true;
            request.TargetReference = new Amazon.CloudDirectory.Model.ObjectReference();
            System.String requestTargetReference_targetReference_Selector = null;
            if (cmdletContext.TargetReference_Selector != null)
            {
                requestTargetReference_targetReference_Selector = cmdletContext.TargetReference_Selector;
            }
            if (requestTargetReference_targetReference_Selector != null)
            {
                request.TargetReference.Selector = requestTargetReference_targetReference_Selector;
                requestTargetReferenceIsNull = false;
            }
             // determine if request.TargetReference should be set to null
            if (requestTargetReferenceIsNull)
            {
                request.TargetReference = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DetachedObjectIdentifier;
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
        
        private static Amazon.CloudDirectory.Model.DetachFromIndexResponse CallAWSServiceOperation(IAmazonCloudDirectory client, Amazon.CloudDirectory.Model.DetachFromIndexRequest request)
        {
            #if DESKTOP
            return client.DetachFromIndex(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DetachFromIndexAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DirectoryArn { get; set; }
            public System.String IndexReference_Selector { get; set; }
            public System.String TargetReference_Selector { get; set; }
        }
        
    }
}
