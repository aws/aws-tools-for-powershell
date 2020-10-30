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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates an existing Amazon Kendra index.
    /// </summary>
    [Cmdlet("Update", "KNDRIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateIndex API operation.", Operation = new[] {"UpdateIndex"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateIndexResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateIndexResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateIndexResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKNDRIndexCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DocumentMetadataConfigurationUpdate
        /// <summary>
        /// <para>
        /// <para>The document metadata to update. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DocumentMetadataConfigurationUpdates")]
        public Amazon.Kendra.Model.DocumentMetadataConfiguration[] DocumentMetadataConfigurationUpdate { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the index to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the index to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CapacityUnits_QueryCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The amount of extra query capacity for an index. Each capacity unit provides 0.5 queries
        /// per second and 40,000 queries per day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityUnits_QueryCapacityUnits")]
        public System.Int32? CapacityUnits_QueryCapacityUnit { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>A new IAM role that gives Amazon Kendra permission to access your Amazon CloudWatch
        /// logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter CapacityUnits_StorageCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The amount of extra storage capacity for an index. Each capacity unit provides 150
        /// Gb of storage space or 500,000 documents, whichever is reached first.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityUnits_StorageCapacityUnits")]
        public System.Int32? CapacityUnits_StorageCapacityUnit { get; set; }
        #endregion
        
        #region Parameter UserContextPolicy
        /// <summary>
        /// <para>
        /// <para>The user user token context policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kendra.UserContextPolicy")]
        public Amazon.Kendra.UserContextPolicy UserContextPolicy { get; set; }
        #endregion
        
        #region Parameter UserTokenConfiguration
        /// <summary>
        /// <para>
        /// <para>The user token configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserTokenConfigurations")]
        public Amazon.Kendra.Model.UserTokenConfiguration[] UserTokenConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateIndexResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRIndex (UpdateIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateIndexResponse, UpdateKNDRIndexCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CapacityUnits_QueryCapacityUnit = this.CapacityUnits_QueryCapacityUnit;
            context.CapacityUnits_StorageCapacityUnit = this.CapacityUnits_StorageCapacityUnit;
            context.Description = this.Description;
            if (this.DocumentMetadataConfigurationUpdate != null)
            {
                context.DocumentMetadataConfigurationUpdate = new List<Amazon.Kendra.Model.DocumentMetadataConfiguration>(this.DocumentMetadataConfigurationUpdate);
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            context.UserContextPolicy = this.UserContextPolicy;
            if (this.UserTokenConfiguration != null)
            {
                context.UserTokenConfiguration = new List<Amazon.Kendra.Model.UserTokenConfiguration>(this.UserTokenConfiguration);
            }
            
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
            var request = new Amazon.Kendra.Model.UpdateIndexRequest();
            
            
             // populate CapacityUnits
            var requestCapacityUnitsIsNull = true;
            request.CapacityUnits = new Amazon.Kendra.Model.CapacityUnitsConfiguration();
            System.Int32? requestCapacityUnits_capacityUnits_QueryCapacityUnit = null;
            if (cmdletContext.CapacityUnits_QueryCapacityUnit != null)
            {
                requestCapacityUnits_capacityUnits_QueryCapacityUnit = cmdletContext.CapacityUnits_QueryCapacityUnit.Value;
            }
            if (requestCapacityUnits_capacityUnits_QueryCapacityUnit != null)
            {
                request.CapacityUnits.QueryCapacityUnits = requestCapacityUnits_capacityUnits_QueryCapacityUnit.Value;
                requestCapacityUnitsIsNull = false;
            }
            System.Int32? requestCapacityUnits_capacityUnits_StorageCapacityUnit = null;
            if (cmdletContext.CapacityUnits_StorageCapacityUnit != null)
            {
                requestCapacityUnits_capacityUnits_StorageCapacityUnit = cmdletContext.CapacityUnits_StorageCapacityUnit.Value;
            }
            if (requestCapacityUnits_capacityUnits_StorageCapacityUnit != null)
            {
                request.CapacityUnits.StorageCapacityUnits = requestCapacityUnits_capacityUnits_StorageCapacityUnit.Value;
                requestCapacityUnitsIsNull = false;
            }
             // determine if request.CapacityUnits should be set to null
            if (requestCapacityUnitsIsNull)
            {
                request.CapacityUnits = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DocumentMetadataConfigurationUpdate != null)
            {
                request.DocumentMetadataConfigurationUpdates = cmdletContext.DocumentMetadataConfigurationUpdate;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.UserContextPolicy != null)
            {
                request.UserContextPolicy = cmdletContext.UserContextPolicy;
            }
            if (cmdletContext.UserTokenConfiguration != null)
            {
                request.UserTokenConfigurations = cmdletContext.UserTokenConfiguration;
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
        
        private Amazon.Kendra.Model.UpdateIndexResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateIndex");
            try
            {
                #if DESKTOP
                return client.UpdateIndex(request);
                #elif CORECLR
                return client.UpdateIndexAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? CapacityUnits_QueryCapacityUnit { get; set; }
            public System.Int32? CapacityUnits_StorageCapacityUnit { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.Kendra.Model.DocumentMetadataConfiguration> DocumentMetadataConfigurationUpdate { get; set; }
            public System.String Id { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.Kendra.UserContextPolicy UserContextPolicy { get; set; }
            public List<Amazon.Kendra.Model.UserTokenConfiguration> UserTokenConfiguration { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateIndexResponse, UpdateKNDRIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
