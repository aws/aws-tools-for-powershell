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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Update a network instance.
    /// 
    ///  
    /// <para>
    /// A network instance is a single network created in Amazon Web Services TNB that can
    /// be deployed and on which life-cycle operations (like terminate, update, and delete)
    /// can be performed.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TNBSolNetworkInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Telco Network Builder UpdateSolNetworkInstance API operation.", Operation = new[] {"UpdateSolNetworkInstance"}, SelectReturnType = typeof(Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse))]
    [AWSCmdletOutput("System.String or Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTNBSolNetworkInstanceCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NsInstanceId
        /// <summary>
        /// <para>
        /// <para>ID of the network instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NsInstanceId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A tag is a label that you assign to an Amazon Web Services resource. Each tag consists
        /// of a key and an optional value. When you use this API, the tags are transferred to
        /// the network operation that is created. Use tags to search and filter your resources
        /// or track your Amazon Web Services costs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UpdateType
        /// <summary>
        /// <para>
        /// <para>The type of update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Tnb.UpdateSolNetworkType")]
        public Amazon.Tnb.UpdateSolNetworkType UpdateType { get; set; }
        #endregion
        
        #region Parameter ModifyVnfInfoData_VnfConfigurableProperty
        /// <summary>
        /// <para>
        /// <para>Provides values for the configurable properties declared in the function package descriptor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModifyVnfInfoData_VnfConfigurableProperties")]
        public System.Management.Automation.PSObject ModifyVnfInfoData_VnfConfigurableProperty { get; set; }
        #endregion
        
        #region Parameter ModifyVnfInfoData_VnfInstanceId
        /// <summary>
        /// <para>
        /// <para>ID of the network function instance.</para><para>A network function instance is a function in a function package .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModifyVnfInfoData_VnfInstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NsLcmOpOccId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NsLcmOpOccId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NsInstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TNBSolNetworkInstance (UpdateSolNetworkInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse, UpdateTNBSolNetworkInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ModifyVnfInfoData_VnfConfigurableProperty = this.ModifyVnfInfoData_VnfConfigurableProperty;
            context.ModifyVnfInfoData_VnfInstanceId = this.ModifyVnfInfoData_VnfInstanceId;
            context.NsInstanceId = this.NsInstanceId;
            #if MODULAR
            if (this.NsInstanceId == null && ParameterWasBound(nameof(this.NsInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.UpdateType = this.UpdateType;
            #if MODULAR
            if (this.UpdateType == null && ParameterWasBound(nameof(this.UpdateType)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Tnb.Model.UpdateSolNetworkInstanceRequest();
            
            
             // populate ModifyVnfInfoData
            var requestModifyVnfInfoDataIsNull = true;
            request.ModifyVnfInfoData = new Amazon.Tnb.Model.UpdateSolNetworkModify();
            Amazon.Runtime.Documents.Document? requestModifyVnfInfoData_modifyVnfInfoData_VnfConfigurableProperty = null;
            if (cmdletContext.ModifyVnfInfoData_VnfConfigurableProperty != null)
            {
                requestModifyVnfInfoData_modifyVnfInfoData_VnfConfigurableProperty = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ModifyVnfInfoData_VnfConfigurableProperty);
            }
            if (requestModifyVnfInfoData_modifyVnfInfoData_VnfConfigurableProperty != null)
            {
                request.ModifyVnfInfoData.VnfConfigurableProperties = requestModifyVnfInfoData_modifyVnfInfoData_VnfConfigurableProperty.Value;
                requestModifyVnfInfoDataIsNull = false;
            }
            System.String requestModifyVnfInfoData_modifyVnfInfoData_VnfInstanceId = null;
            if (cmdletContext.ModifyVnfInfoData_VnfInstanceId != null)
            {
                requestModifyVnfInfoData_modifyVnfInfoData_VnfInstanceId = cmdletContext.ModifyVnfInfoData_VnfInstanceId;
            }
            if (requestModifyVnfInfoData_modifyVnfInfoData_VnfInstanceId != null)
            {
                request.ModifyVnfInfoData.VnfInstanceId = requestModifyVnfInfoData_modifyVnfInfoData_VnfInstanceId;
                requestModifyVnfInfoDataIsNull = false;
            }
             // determine if request.ModifyVnfInfoData should be set to null
            if (requestModifyVnfInfoDataIsNull)
            {
                request.ModifyVnfInfoData = null;
            }
            if (cmdletContext.NsInstanceId != null)
            {
                request.NsInstanceId = cmdletContext.NsInstanceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UpdateType != null)
            {
                request.UpdateType = cmdletContext.UpdateType;
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
        
        private Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.UpdateSolNetworkInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "UpdateSolNetworkInstance");
            try
            {
                #if DESKTOP
                return client.UpdateSolNetworkInstance(request);
                #elif CORECLR
                return client.UpdateSolNetworkInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject ModifyVnfInfoData_VnfConfigurableProperty { get; set; }
            public System.String ModifyVnfInfoData_VnfInstanceId { get; set; }
            public System.String NsInstanceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Tnb.UpdateSolNetworkType UpdateType { get; set; }
            public System.Func<Amazon.Tnb.Model.UpdateSolNetworkInstanceResponse, UpdateTNBSolNetworkInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NsLcmOpOccId;
        }
        
    }
}
