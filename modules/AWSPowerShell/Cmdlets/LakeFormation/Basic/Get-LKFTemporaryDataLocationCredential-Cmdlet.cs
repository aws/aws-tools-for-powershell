/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.LakeFormation;
using Amazon.LakeFormation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LKF
{
    /// <summary>
    /// Allows a user or application in a secure environment to access data in a specific
    /// Amazon S3 location registered with Lake Formation by providing temporary scoped credentials
    /// that are limited to the requested data location and the caller's authorized access
    /// level.
    /// 
    ///  
    /// <para>
    ///  The API operation returns an error in the following scenarios:
    /// </para><ul><li><para>
    /// The data location is not registered with Lake Formation. 
    /// </para></li><li><para>
    /// No Glue table is associated with the data location.
    /// </para></li><li><para>
    /// The caller doesn't have required permissions on the associated table. The caller must
    /// have <c>SELECT</c> or <c>SUPER</c> permissions on the associated table, and credential
    /// vending for full table access must be enabled in the data lake settings. 
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/lake-formation/latest/dg/full-table-credential-vending.html">Application
    /// integration for full table access</a>.
    /// </para></li><li><para>
    /// The data location is in a different Amazon Web Services Region. Lake Formation doesn't
    /// support cross-Region access when vending credentials for a data location. Lake Formation
    /// only supports Amazon S3 paths registered within the same Region as the API call. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "LKFTemporaryDataLocationCredential")]
    [OutputType("Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse")]
    [AWSCmdlet("Calls the AWS Lake Formation GetTemporaryDataLocationCredentials API operation.", Operation = new[] {"GetTemporaryDataLocationCredentials"}, SelectReturnType = typeof(Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse))]
    [AWSCmdletOutput("Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse",
        "This cmdlet returns an Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse object containing multiple properties."
    )]
    public partial class GetLKFTemporaryDataLocationCredentialCmdlet : AmazonLakeFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuditContext_AdditionalAuditContext
        /// <summary>
        /// <para>
        /// <para>The filter engine can populate the 'AdditionalAuditContext' information with the request
        /// ID for you to track. This information will be displayed in CloudTrail log in your
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuditContext_AdditionalAuditContext { get; set; }
        #endregion
        
        #region Parameter CredentialsScope
        /// <summary>
        /// <para>
        /// <para>The credential scope is determined by the caller's Lake Formation permission on the
        /// associated table. Credential scope can be either:</para><ul><li><para>READ - Provides read-only access to the data location.</para></li><li><para>READ_WRITE - Provides both read and write access to the data location.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LakeFormation.CredentialsScope")]
        public Amazon.LakeFormation.CredentialsScope CredentialsScope { get; set; }
        #endregion
        
        #region Parameter DataLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 data location that you want to access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataLocations")]
        public System.String[] DataLocation { get; set; }
        #endregion
        
        #region Parameter DurationSecond
        /// <summary>
        /// <para>
        /// <para>The time period, between 900 and 43,200 seconds, for the timeout of the temporary
        /// credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse).
        /// Specifying the name of a property of type Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse, GetLKFTemporaryDataLocationCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AuditContext_AdditionalAuditContext = this.AuditContext_AdditionalAuditContext;
            context.CredentialsScope = this.CredentialsScope;
            if (this.DataLocation != null)
            {
                context.DataLocation = new List<System.String>(this.DataLocation);
            }
            context.DurationSecond = this.DurationSecond;
            
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
            var request = new Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsRequest();
            
            
             // populate AuditContext
            var requestAuditContextIsNull = true;
            request.AuditContext = new Amazon.LakeFormation.Model.AuditContext();
            System.String requestAuditContext_auditContext_AdditionalAuditContext = null;
            if (cmdletContext.AuditContext_AdditionalAuditContext != null)
            {
                requestAuditContext_auditContext_AdditionalAuditContext = cmdletContext.AuditContext_AdditionalAuditContext;
            }
            if (requestAuditContext_auditContext_AdditionalAuditContext != null)
            {
                request.AuditContext.AdditionalAuditContext = requestAuditContext_auditContext_AdditionalAuditContext;
                requestAuditContextIsNull = false;
            }
             // determine if request.AuditContext should be set to null
            if (requestAuditContextIsNull)
            {
                request.AuditContext = null;
            }
            if (cmdletContext.CredentialsScope != null)
            {
                request.CredentialsScope = cmdletContext.CredentialsScope;
            }
            if (cmdletContext.DataLocation != null)
            {
                request.DataLocations = cmdletContext.DataLocation;
            }
            if (cmdletContext.DurationSecond != null)
            {
                request.DurationSeconds = cmdletContext.DurationSecond.Value;
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
        
        private Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse CallAWSServiceOperation(IAmazonLakeFormation client, Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lake Formation", "GetTemporaryDataLocationCredentials");
            try
            {
                return client.GetTemporaryDataLocationCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AuditContext_AdditionalAuditContext { get; set; }
            public Amazon.LakeFormation.CredentialsScope CredentialsScope { get; set; }
            public List<System.String> DataLocation { get; set; }
            public System.Int32? DurationSecond { get; set; }
            public System.Func<Amazon.LakeFormation.Model.GetTemporaryDataLocationCredentialsResponse, GetLKFTemporaryDataLocationCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
