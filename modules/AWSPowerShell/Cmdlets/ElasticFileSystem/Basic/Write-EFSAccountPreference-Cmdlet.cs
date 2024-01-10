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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Use this operation to set the account preference in the current Amazon Web Services
    /// Region to use long 17 character (63 bit) or short 8 character (32 bit) resource IDs
    /// for new EFS file system and mount target resources. All existing resource IDs are
    /// not affected by any changes you make. You can set the ID preference during the opt-in
    /// period as EFS transitions to long resource IDs. For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/manage-efs-resource-ids.html">Managing
    /// Amazon EFS resource IDs</a>.
    /// 
    ///  <note><para>
    /// Starting in October, 2021, you will receive an error if you try to set the account
    /// preference to use the short 8 character format resource ID. Contact Amazon Web Services
    /// support if you receive an error and must use short IDs for file system and mount target
    /// resources.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "EFSAccountPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.ResourceIdPreference")]
    [AWSCmdlet("Calls the Amazon Elastic File System PutAccountPreferences API operation.", Operation = new[] {"PutAccountPreferences"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.ResourceIdPreference or Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.ResourceIdPreference object.",
        "The service call response (type Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteEFSAccountPreferenceCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResourceIdType
        /// <summary>
        /// <para>
        /// <para>Specifies the EFS resource ID preference to set for the user's Amazon Web Services
        /// account, in the current Amazon Web Services Region, either <c>LONG_ID</c> (17 characters),
        /// or <c>SHORT_ID</c> (8 characters).</para><note><para>Starting in October, 2021, you will receive an error when setting the account preference
        /// to <c>SHORT_ID</c>. Contact Amazon Web Services support if you receive an error and
        /// must use short IDs for file system and mount target resources.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.ResourceIdType")]
        public Amazon.ElasticFileSystem.ResourceIdType ResourceIdType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceIdPreference'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceIdPreference";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceIdType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceIdType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceIdType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EFSAccountPreference (PutAccountPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse, WriteEFSAccountPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceIdType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceIdType = this.ResourceIdType;
            #if MODULAR
            if (this.ResourceIdType == null && ParameterWasBound(nameof(this.ResourceIdType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElasticFileSystem.Model.PutAccountPreferencesRequest();
            
            if (cmdletContext.ResourceIdType != null)
            {
                request.ResourceIdType = cmdletContext.ResourceIdType;
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
        
        private Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.PutAccountPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "PutAccountPreferences");
            try
            {
                #if DESKTOP
                return client.PutAccountPreferences(request);
                #elif CORECLR
                return client.PutAccountPreferencesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ElasticFileSystem.ResourceIdType ResourceIdType { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.PutAccountPreferencesResponse, WriteEFSAccountPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceIdPreference;
        }
        
    }
}
