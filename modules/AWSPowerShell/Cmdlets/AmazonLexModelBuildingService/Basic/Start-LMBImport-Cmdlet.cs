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
using Amazon.LexModelBuildingService;
using Amazon.LexModelBuildingService.Model;

namespace Amazon.PowerShell.Cmdlets.LMB
{
    /// <summary>
    /// Starts a job to import a resource to Amazon Lex.
    /// </summary>
    [Cmdlet("Start", "LMBImport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LexModelBuildingService.Model.StartImportResponse")]
    [AWSCmdlet("Calls the Amazon Lex Model Building Service StartImport API operation.", Operation = new[] {"StartImport"})]
    [AWSCmdletOutput("Amazon.LexModelBuildingService.Model.StartImportResponse",
        "This cmdlet returns a Amazon.LexModelBuildingService.Model.StartImportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartLMBImportCmdlet : AmazonLexModelBuildingServiceClientCmdlet, IExecutor
    {
        
        #region Parameter MergeStrategy
        /// <summary>
        /// <para>
        /// <para>Specifies the action that the <code>StartImport</code> operation should take when
        /// there is an existing resource with the same name.</para><ul><li><para>FAIL_ON_CONFLICT - The import operation is stopped on the first conflict between a
        /// resource in the import file and an existing resource. The name of the resource causing
        /// the conflict is in the <code>failureReason</code> field of the response to the <code>GetImport</code>
        /// operation.</para><para>OVERWRITE_LATEST - The import operation proceeds even if there is a conflict with
        /// an existing resource. The $LASTEST version of the existing resource is overwritten
        /// with the data from the import file.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.MergeStrategy")]
        public Amazon.LexModelBuildingService.MergeStrategy MergeStrategy { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>A zip archive in binary format. The archive should contain one file, a JSON file containing
        /// the resource to import. The resource should match the type specified in the <code>resourceType</code>
        /// field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] Payload { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of resource to export. Each resource also exports any resources
        /// that it depends on. </para><ul><li><para>A bot exports dependent intents.</para></li><li><para>An intent exports dependent slot types.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.LexModelBuildingService.ResourceType")]
        public Amazon.LexModelBuildingService.ResourceType ResourceType { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LMBImport (StartImport)"))
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
            
            context.MergeStrategy = this.MergeStrategy;
            context.Payload = this.Payload;
            context.ResourceType = this.ResourceType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _PayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.LexModelBuildingService.Model.StartImportRequest();
                
                if (cmdletContext.MergeStrategy != null)
                {
                    request.MergeStrategy = cmdletContext.MergeStrategy;
                }
                if (cmdletContext.Payload != null)
                {
                    _PayloadStream = new System.IO.MemoryStream(cmdletContext.Payload);
                    request.Payload = _PayloadStream;
                }
                if (cmdletContext.ResourceType != null)
                {
                    request.ResourceType = cmdletContext.ResourceType;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
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
            finally
            {
                if( _PayloadStream != null)
                {
                    _PayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LexModelBuildingService.Model.StartImportResponse CallAWSServiceOperation(IAmazonLexModelBuildingService client, Amazon.LexModelBuildingService.Model.StartImportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lex Model Building Service", "StartImport");
            try
            {
                #if DESKTOP
                return client.StartImport(request);
                #elif CORECLR
                return client.StartImportAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LexModelBuildingService.MergeStrategy MergeStrategy { get; set; }
            public byte[] Payload { get; set; }
            public Amazon.LexModelBuildingService.ResourceType ResourceType { get; set; }
        }
        
    }
}
