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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Associates the specified SSM document with the specified instances.
    /// 
    ///  
    /// <para>
    /// When you associate an SSM document with an instance, the configuration agent on the
    /// instance processes the document and configures the instance as specified.
    /// </para><para>
    /// If you associate a document with an instance that already has an associated document,
    /// the system throws the AssociationAlreadyExists exception.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SSMAssociationFromBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse")]
    [AWSCmdlet("Invokes the CreateAssociationBatch operation against Amazon Simple Systems Management.", Operation = new[] {"CreateAssociationBatch"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSSMAssociationFromBatchCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more associations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Entries")]
        public Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry[] Entry { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Entry", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMAssociationFromBatch (CreateAssociationBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Entry != null)
            {
                context.Entries = new List<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry>(this.Entry);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequest();
            
            if (cmdletContext.Entries != null)
            {
                request.Entries = cmdletContext.Entries;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateAssociationBatch(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.SimpleSystemsManagement.Model.CreateAssociationBatchRequestEntry> Entries { get; set; }
        }
        
    }
}
