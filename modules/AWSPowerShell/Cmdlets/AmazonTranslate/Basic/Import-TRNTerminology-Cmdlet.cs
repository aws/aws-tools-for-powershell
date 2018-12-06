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
using Amazon.Translate;
using Amazon.Translate.Model;

namespace Amazon.PowerShell.Cmdlets.TRN
{
    /// <summary>
    /// Creates or updates a custom terminology, depending on whether or not one already exists
    /// for the given terminology name. Importing a terminology with the same name as an existing
    /// one will merge the terminologies based on the chosen merge strategy. Currently, the
    /// only supported merge strategy is OVERWRITE, and so the imported terminology will overwrite
    /// an existing terminology of the same name.
    /// 
    ///  
    /// <para>
    /// If you import a terminology that overwrites an existing one, the new terminology take
    /// up to 10 minutes to fully propagate and be available for use in a translation due
    /// to cache policies with the DataPlane service that performs the translations.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "TRNTerminology", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Translate.Model.TerminologyProperties")]
    [AWSCmdlet("Calls the Amazon Translate ImportTerminology API operation.", Operation = new[] {"ImportTerminology"})]
    [AWSCmdletOutput("Amazon.Translate.Model.TerminologyProperties",
        "This cmdlet returns a TerminologyProperties object.",
        "The service call response (type Amazon.Translate.Model.ImportTerminologyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportTRNTerminologyCmdlet : AmazonTranslateClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the custom terminology being imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TerminologyData_File
        /// <summary>
        /// <para>
        /// <para>The file containing the custom terminology data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] TerminologyData_File { get; set; }
        #endregion
        
        #region Parameter TerminologyData_Format
        /// <summary>
        /// <para>
        /// <para>The data format of the custom terminology. Either CSV or TMX.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Translate.TerminologyDataFormat")]
        public Amazon.Translate.TerminologyDataFormat TerminologyData_Format { get; set; }
        #endregion
        
        #region Parameter EncryptionKey_Id
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the encryption key being used to encrypt the custom
        /// terminology.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EncryptionKey_Id { get; set; }
        #endregion
        
        #region Parameter MergeStrategy
        /// <summary>
        /// <para>
        /// <para>The merge strategy of the custom terminology being imported. Currently, only the OVERWRITE
        /// merge strategy is supported. In this case, the imported terminology will overwrite
        /// an existing terminology of the same name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Translate.MergeStrategy")]
        public Amazon.Translate.MergeStrategy MergeStrategy { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the custom terminology being imported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter EncryptionKey_Type
        /// <summary>
        /// <para>
        /// <para>The type of encryption key used by Amazon Translate to encrypt custom terminologies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Translate.EncryptionKeyType")]
        public Amazon.Translate.EncryptionKeyType EncryptionKey_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-TRNTerminology (ImportTerminology)"))
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
            
            context.Description = this.Description;
            context.EncryptionKey_Id = this.EncryptionKey_Id;
            context.EncryptionKey_Type = this.EncryptionKey_Type;
            context.MergeStrategy = this.MergeStrategy;
            context.Name = this.Name;
            context.TerminologyData_File = this.TerminologyData_File;
            context.TerminologyData_Format = this.TerminologyData_Format;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _TerminologyData_FileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Translate.Model.ImportTerminologyRequest();
                
                if (cmdletContext.Description != null)
                {
                    request.Description = cmdletContext.Description;
                }
                
                 // populate EncryptionKey
                bool requestEncryptionKeyIsNull = true;
                request.EncryptionKey = new Amazon.Translate.Model.EncryptionKey();
                System.String requestEncryptionKey_encryptionKey_Id = null;
                if (cmdletContext.EncryptionKey_Id != null)
                {
                    requestEncryptionKey_encryptionKey_Id = cmdletContext.EncryptionKey_Id;
                }
                if (requestEncryptionKey_encryptionKey_Id != null)
                {
                    request.EncryptionKey.Id = requestEncryptionKey_encryptionKey_Id;
                    requestEncryptionKeyIsNull = false;
                }
                Amazon.Translate.EncryptionKeyType requestEncryptionKey_encryptionKey_Type = null;
                if (cmdletContext.EncryptionKey_Type != null)
                {
                    requestEncryptionKey_encryptionKey_Type = cmdletContext.EncryptionKey_Type;
                }
                if (requestEncryptionKey_encryptionKey_Type != null)
                {
                    request.EncryptionKey.Type = requestEncryptionKey_encryptionKey_Type;
                    requestEncryptionKeyIsNull = false;
                }
                 // determine if request.EncryptionKey should be set to null
                if (requestEncryptionKeyIsNull)
                {
                    request.EncryptionKey = null;
                }
                if (cmdletContext.MergeStrategy != null)
                {
                    request.MergeStrategy = cmdletContext.MergeStrategy;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                
                 // populate TerminologyData
                bool requestTerminologyDataIsNull = true;
                request.TerminologyData = new Amazon.Translate.Model.TerminologyData();
                System.IO.MemoryStream requestTerminologyData_terminologyData_File = null;
                if (cmdletContext.TerminologyData_File != null)
                {
                    _TerminologyData_FileStream = new System.IO.MemoryStream(cmdletContext.TerminologyData_File);
                    requestTerminologyData_terminologyData_File = _TerminologyData_FileStream;
                }
                if (requestTerminologyData_terminologyData_File != null)
                {
                    request.TerminologyData.File = requestTerminologyData_terminologyData_File;
                    requestTerminologyDataIsNull = false;
                }
                Amazon.Translate.TerminologyDataFormat requestTerminologyData_terminologyData_Format = null;
                if (cmdletContext.TerminologyData_Format != null)
                {
                    requestTerminologyData_terminologyData_Format = cmdletContext.TerminologyData_Format;
                }
                if (requestTerminologyData_terminologyData_Format != null)
                {
                    request.TerminologyData.Format = requestTerminologyData_terminologyData_Format;
                    requestTerminologyDataIsNull = false;
                }
                 // determine if request.TerminologyData should be set to null
                if (requestTerminologyDataIsNull)
                {
                    request.TerminologyData = null;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.TerminologyProperties;
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
                if( _TerminologyData_FileStream != null)
                {
                    _TerminologyData_FileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Translate.Model.ImportTerminologyResponse CallAWSServiceOperation(IAmazonTranslate client, Amazon.Translate.Model.ImportTerminologyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Translate", "ImportTerminology");
            try
            {
                #if DESKTOP
                return client.ImportTerminology(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportTerminologyAsync(request);
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
            public System.String Description { get; set; }
            public System.String EncryptionKey_Id { get; set; }
            public Amazon.Translate.EncryptionKeyType EncryptionKey_Type { get; set; }
            public Amazon.Translate.MergeStrategy MergeStrategy { get; set; }
            public System.String Name { get; set; }
            public byte[] TerminologyData_File { get; set; }
            public Amazon.Translate.TerminologyDataFormat TerminologyData_Format { get; set; }
        }
        
    }
}
