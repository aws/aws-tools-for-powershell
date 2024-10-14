/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Retrieves the security configuration for a specified catalog.
    /// </summary>
    [Cmdlet("Get", "GLUEDataCatalogEncryptionSetting")]
    [OutputType("Amazon.Glue.Model.DataCatalogEncryptionSettings")]
    [AWSCmdlet("Calls the AWS Glue GetDataCatalogEncryptionSettings API operation.", Operation = new[] {"GetDataCatalogEncryptionSettings"}, SelectReturnType = typeof(Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.DataCatalogEncryptionSettings or Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse",
        "This cmdlet returns an Amazon.Glue.Model.DataCatalogEncryptionSettings object.",
        "The service call response (type Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetGLUEDataCatalogEncryptionSettingCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CatalogId
        /// <summary>
        /// <para>
        /// <para>The ID of the Data Catalog to retrieve the security configuration for. If none is
        /// provided, the Amazon Web Services account ID is used by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CatalogId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataCatalogEncryptionSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataCatalogEncryptionSettings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CatalogId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CatalogId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse, GetGLUEDataCatalogEncryptionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CatalogId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CatalogId = this.CatalogId;
            
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
            var request = new Amazon.Glue.Model.GetDataCatalogEncryptionSettingsRequest();
            
            if (cmdletContext.CatalogId != null)
            {
                request.CatalogId = cmdletContext.CatalogId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.GetDataCatalogEncryptionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "GetDataCatalogEncryptionSettings");
            try
            {
                #if DESKTOP
                return client.GetDataCatalogEncryptionSettings(request);
                #elif CORECLR
                return client.GetDataCatalogEncryptionSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String CatalogId { get; set; }
            public System.Func<Amazon.Glue.Model.GetDataCatalogEncryptionSettingsResponse, GetGLUEDataCatalogEncryptionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataCatalogEncryptionSettings;
        }
        
    }
}
